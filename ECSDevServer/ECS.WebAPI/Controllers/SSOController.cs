using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Models;
using System;
using System.Net;
using System.Net.Http;
using ECS.Repositories.Implementations;
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
        private readonly IPartialAccountRepository _partialAccountRepository;
        private readonly IJAccessTokenRepository _jwtAccessTokenRepository;
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;
        private readonly ISaltRepository _saltRepository;
        private readonly IPartialAccountSaltRepository _partialAccountSaltRepository;

        public SsoController()
        {
            _accountRepository = new AccountRepository();
            _partialAccountRepository = new PartialAccountRepository();
            _jwtAccessTokenRepository = new JAccessTokenRepository();
            _saltRepository = new SaltRepository();
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
            _partialAccountSaltRepository = new PartialAccountSaltRepository();
        }
        public SsoController(IAccountRepository accountRepo, IPartialAccountRepository partialAccountRepo,
            IJAccessTokenRepository jwtRepo, ISaltRepository saltRepo, IExpiredAccessTokenRepository ssoAccessTokenRepo,
            IPartialAccountSaltRepository partialAccountSaltRepo)
        {
            _accountRepository = accountRepo;
            _partialAccountRepository = partialAccountRepo;
            _jwtAccessTokenRepository = jwtRepo;
            _saltRepository = saltRepo;
            _expiredAccessTokenRepository = ssoAccessTokenRepo;
            _partialAccountSaltRepository = partialAccountSaltRepo;
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

            // The suspension time doesn't make sense to have in there.
            var partialAccount = new PartialAccount()
            {
                UserName = ssoDto.Username,
                Password = ssoDto.HashedPassword,
                AccountType = ssoDto.RoleType
            };
            _partialAccountRepository.Insert(partialAccount);

            var salt = new PartialAccountSalt()
            {
                PasswordSalt = ssoDto.PasswordSalt,
                UserName = ssoDto.Username
            };
            _partialAccountSaltRepository.Insert(salt);

            return Ok();
        }

        [HttpGet]
        public HttpResponseMessage LoginRedirect()
        {
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("http://localhost:8080/#/Main");
            response.Headers.Add("Access-Control-Allow-Origin", Request.Headers.GetValues("Origin"));
            response.Headers.Add("Access-Control-Allow-Credentials", "true");
            response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
            return response;
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
            var transformer = new SsoLoginTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // Grab the accounts to check for username and password
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
            var partialAccount = _partialAccountRepository.GetSingle(partial => partial.UserName == ssoDto.Username);

            // TODO: @Scott Sso Login needs to generate a token with a username AND list of claims. Get claims from account.
            // Generate our token for them.
            var token = JwtManager.Instance.GenerateToken(ssoDto.Username);

            // If accounts exist in both tables, there is a database problem.
            if (partialAccount != null && account != null)
            {
                return Content(HttpStatusCode.InternalServerError, "Database Inconsistent");
            }

            // If the partial account exists, then the Account needs a full registration. Redirect them.
            if (partialAccount != null)
            {
                return Content(HttpStatusCode.Redirect, new Uri("http://localhost:8080/#/partial-registration?jwt=" + token));
            }

            // If the account does not exist, kick them out.
            if (account == null)
            {
                return BadRequest("Invalid Credentials");
            }

            // Get the password salt by username.
            var saltModel = _saltRepository.GetSingle(model => model.UserName == ssoDto.Username);
            if (saltModel == null)
            {
                return Content(HttpStatusCode.Conflict, "You have not created a salt yet");
            }
            var salt = saltModel.PasswordSalt;

            // Make sure you append the salt, not prepend (group decision).
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(salt, ssoDto.Username, false);
            if (!account.Password.Equals(hashedPassword))
            {
                return Unauthorized();
            }

            // Grab the previous access token associated with the account.
            var accountAccessToken = _jwtAccessTokenRepository.GetSingle(oldToken => oldToken.UserName == ssoDto.Username);

            // If the token is not null, that means they did sign in through our system already, and we need to update their jwt.
            if (accountAccessToken == null)
            {
                return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/Sso/Login?jwt=" + token));
            }
                
            // Set current account token to expired list.
            var deadToken = new ExpiredAccessToken
            {
                ExpiredTokenValue = accountAccessToken.Value
            };
            _expiredAccessTokenRepository.Insert(deadToken);
            

            // Store updated account token in DB.
            accountAccessToken.Value = token;
            _jwtAccessTokenRepository.Update(accountAccessToken);

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/Sso/Login?jwt=" + token));

        }

        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            var transformer = new SsoResetPasswordTransformer();
            var ssoDto = transformer.Fetch(this.RequestContext);
            
            // Get related account from username
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
            var partialAccount = _partialAccountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);

            // If accounts exist in both tables, there is a database problem.
            if (partialAccount != null && account != null)
            {
                return Content(HttpStatusCode.InternalServerError, "Database Inconsistent");
            }

            // If the full account has been made, produce the change there.
            if (account != null)
            {
                // Update password for account
                account.Password = ssoDto.HashedNewPassword;
                _accountRepository.Update(account);

                // Update salt table related to account
                var salt = _saltRepository.GetSingle(model => model.UserName == ssoDto.Username);
                salt.PasswordSalt = ssoDto.PasswordSalt;
                _saltRepository.Update(salt);
            }

            if (partialAccount != null)
            {
                // Update password for account
                partialAccount.Password = ssoDto.HashedNewPassword;
                _partialAccountRepository.Update(partialAccount);

                // Update salt table related to account
                var partialAccountSalt = _partialAccountSaltRepository.GetSingle(model => model.UserName == ssoDto.Username);
                partialAccountSalt.PasswordSalt = ssoDto.PasswordSalt;
                _partialAccountSaltRepository.Update(partialAccountSalt);
            }

            return Ok("Account password successfully updated.");
        }
    }
}