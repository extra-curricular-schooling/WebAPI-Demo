using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using System;
using System.Collections;
using System.Net;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("Sso")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET,POST")]
    //[AuthorizeSsoAccessToken]
    public class SsoController : ApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJAccessTokenRepository _jwtAccessTokenRepository;
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;
        private readonly ISaltRepository _saltRepository;

        public SsoController()
        {
            _accountRepository = new AccountRepository();
            _jwtAccessTokenRepository = new JAccessTokenRepository();
            _saltRepository = new SaltRepository();
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
        }
        public SsoController(IAccountRepository accountRepo, IJAccessTokenRepository jwtRepo, ISaltRepository saltRepo, IExpiredAccessTokenRepository ssoAccessTokenRepo)
        {
            _accountRepository = accountRepo;
            _jwtAccessTokenRepository = jwtRepo;
            _saltRepository = saltRepo;
            _expiredAccessTokenRepository = ssoAccessTokenRepo;
        }

        /*
         * When Web API encounters a type implementing this interface as result of an 
         * executed action, instead of running content negotiation, it will call 
         * its only method (Execute) to produce the HttpResponseMessage, and then use that to 
         * respond to the client
         */
        [HttpPost]
        public IHttpActionResult Registration()
        {
            // Transform request context into DTO.
            var transformer = new SsoRegistrationTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // Validate information with the registration DTO, if needed.
            // TODO: @Scott Handle the error that would occur if they try to make a duplicate account.

            // TODO: @Scott The account model is still not acceptable for SSO needs. It requires an email and a mandatory SuspensionTime.
            // The suspension time doesn't make sense to have in there.
            var account = new Account()
            {
                UserName = ssoDto.Username,
                // TODO: @Scott Get rid of the email somehow.
                Email = "_",
                Password = ssoDto.HashedPassword,
                // TODO: @Scott The suspension time is set because exception is thrown trying to convert DateTime2 to DateTime???
                SuspensionTime = DateTime.UtcNow,
                AccountStatus = true,
                FirstTimeUser = true
            };
            _accountRepository.Insert(account);

            var salt = new Salt()
            {
                PasswordSalt = ssoDto.PasswordSalt,
                UserName = ssoDto.Username
            };
            _saltRepository.Insert(salt);

            return Ok();
        }

        // TODO: @Scott Make sure that you finish up your login
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult Login()
        {
            // Transform request context into DTO.
            var transformer = new SsoRegistrationTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // Get the password salt by username.
            var saltModel = _saltRepository.GetSingle(model => model.UserName == ssoDto.Username);
            var salt = saltModel.PasswordSalt;

            // Make sure you append the salt, not prepend (group decision).
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(salt, ssoDto.Username, false);

            // Does the Password check out?
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);

            // TODO @Trish Let Scott know what to do with the First Time Users when they login to our site.
            // Are they a first time user?
            if (account.FirstTimeUser)
            {
                // Redirect them to finish their registration.
                return Ok("Redirect for FirstTimeUsers");
            }

            if (!account.Password.Equals(hashedPassword))
            {
                return Unauthorized();
            }

            // Generate our token for them.

            var token = JwtManager.Instance.GenerateToken(ssoDto.Username);

            // Generate new token based on username and available claims.
            // TODO: @Scott Sso Login needs to generate a token with a username AND list of claims. Get claims from account.
            var claimList = new SortedList
            {
                {"scott", "roberts"}
            };

            // Grab the previous access token associated with the account.
            var accountAccessToken = _jwtAccessTokenRepository.GetSingle(oldToken => oldToken.UserName == ssoDto.Username);

            // If the token is not null, that means they did sign in through our system already, and we need to update their jwt.
            if (accountAccessToken != null)
            {
                // Set current account token to expired list.
                var deadToken = new ExpiredAccessToken
                {
                    ExpiredTokenValue = accountAccessToken.Value
                };
                _expiredAccessTokenRepository.Insert(deadToken);

                accountAccessToken.Value = token;

                // Store updated account token in DB.
                _jwtAccessTokenRepository.Update(accountAccessToken);
            }

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/Sso/Login?jwt=" + token));
        }

        // TODO: @Scott Start working on the Login Get Request
        [HttpGet]
        public IHttpActionResult Login([FromUri] string jwt)
        {
            // This will be the controller that returns the homepage with the user logged in to our app.
            return Ok(jwt);
        }

        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            var transformer = new SsoResetPasswordTransformer();
            var ssoDto = transformer.Fetch(this.RequestContext);
            
            // Get related account from username
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);

            // Update password for account
            account.Password = ssoDto.HashedNewPassword;
            _accountRepository.Update(account);

            // Update salt table related to account
            var saltModel = _saltRepository.GetSingle(model => model.UserName == ssoDto.Username);
            saltModel.PasswordSalt = ssoDto.PasswordSalt;
            _saltRepository.Update(saltModel);
           
            return Ok();
        }
    }
}