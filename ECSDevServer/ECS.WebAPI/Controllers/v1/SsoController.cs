using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST")]
    //[AuthorizeSsoAccessToken]
    public class SsoController : ApiController
    {
        private const string BaseClientUrl = "http://localhost:8080/";

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
        [Route("Registration")]
        public IHttpActionResult Registration()
        {
            // Transform request context into DTO.
            var transformer = new SsoRegistrationTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // Account exists already.
            if (_partialAccountRepository.Exists(acc => acc.UserName == ssoDto.Username) ||
                _accountRepository.Exists(acc => acc.UserName == ssoDto.Username))
            {
                return BadRequest("Duplicate Entry");
            }

            // Add new PartialAccount to the database
            var partialAccount = new PartialAccount()
            {
                UserName = ssoDto.Username,
                Password = ssoDto.HashedPassword,
                AccountType = ssoDto.RoleType
            };
            _partialAccountRepository.Insert(partialAccount);

            // Add new attached Salt to the database connected with PartialAccount.
            var salt = new PartialAccountSalt()
            {
                PasswordSalt = ssoDto.PasswordSalt,
                UserName = ssoDto.Username
            };
            _partialAccountSaltRepository.Insert(salt);

            return Ok();
        }

        /// <summary>
        /// TEST ACTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("LoginRedirect")]
        public HttpResponseMessage LoginRedirect()
        {
            var response = Request.CreateResponse();

            // Transform request context into DTO.
            var transformer = new SsoLoginTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // Grab the accounts to check for username and password
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
            var partialAccount = _partialAccountRepository.GetSingle(partial => partial.UserName == ssoDto.Username);


            // TODO: @Scott Sso Login needs to generate a token with a username AND list of claims. Get claims from account.
            // Generate our token for them.
            var token = JwtManager.Instance.GenerateToken(ssoDto.Username);

            // If the partial account exists, then the Account needs a full registration. Redirect them.
            if (partialAccount != null)
            {
                
                response.StatusCode = HttpStatusCode.MovedPermanently;
                response.Headers.Location = new Uri("http://localhost:8080/partial-registration");
                response.Headers.Add("Access-Control-Allow-Origin", Request.Headers.GetValues("Origin"));
                response.Headers.Add("Access-Control-Allow-Credentials", "true");
                response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login()
        {
            // Transform request context into DTO.
            var transformer = new SsoLoginTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // PARTIAL ACCOUNTS

            // If the partial account exists, then the Account needs a full registration. Redirect them.
            var partialAccount = _partialAccountRepository.GetSingle(partial => partial.UserName == ssoDto.Username);
            if (partialAccount != null)
            {
                // Generate our token for them.
                var partialAccountToken = SsoJwtManager.Instance.GenerateToken(ssoDto.Username);
                // TODO @Scott The Ok response should be a 301 response to redirect the SSO to our client.
                return Ok(new Uri(BaseClientUrl + "partial-registration?jwt=") + partialAccountToken);
            }

            // COMPLETE ACCOUNTS

            // Grab the accounts to check for username and password
            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
            if (account == null)
            {
                return BadRequest("Invalid Credentials");
            }

            // Get the password salt by username.
            var saltModel = _saltRepository.GetSingle(model => model.UserName == ssoDto.Username);
            if (saltModel == null)
            {
                return InternalServerError(new DataException("You have not created a salt yet"));
            }
            var salt = saltModel.PasswordSalt;

            // Make sure you append the salt, not prepend (group decision).
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(salt, ssoDto.Username, false);
            if (!account.Password.Equals(hashedPassword))
            {
                return Unauthorized();
            }

            // Generate a new access token
            var token = JwtManager.Instance.GenerateToken(ssoDto.Username);

            // Grab the previous access token associated with the account.
            var accountAccessToken = _jwtAccessTokenRepository.GetSingle(oldToken => oldToken.UserName == ssoDto.Username);
            if (accountAccessToken != null)
            {
                // Set current account token to expired list.
                var deadToken = new ExpiredAccessToken
                {
                    ExpiredTokenValue = accountAccessToken.Value
                };
                _expiredAccessTokenRepository.Insert(deadToken);
                accountAccessToken.Value = token;
                _jwtAccessTokenRepository.Update(accountAccessToken);
            }
            else
            {
                // Add the new access token and link it the the appropriate account.
                var newToken = new JAccessToken
                {
                    Value = token,
                    UserName = ssoDto.Username,
                    DateTimeIssued = DateTime.UtcNow,
                    Account = account
                };
                _jwtAccessTokenRepository.Insert(newToken);
            }

            // Redirect them to our Home page with their credentials logged.
            // TODO @Scott The Ok response should be a 301 response to redirect the SSO to our client.
            return Ok(new Uri(BaseClientUrl + "home?jwt=" + token));

        }

        [HttpPost]
        [Route("ResetPassword")]
        public IHttpActionResult ResetPassword()
        {
            var transformer = new SsoResetPasswordTransformer();
            var ssoDto = transformer.Fetch(this.RequestContext);
            
            // PARTIAL ACCOUNTS

            var partialAccount = _partialAccountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
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

            // COMPLETE ACCOUNTS

            var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
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

            

            return Ok("Account password successfully updated.");
        }
    }
}