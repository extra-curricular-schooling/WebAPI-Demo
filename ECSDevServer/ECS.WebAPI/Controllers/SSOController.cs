using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;

namespace ECS.WebAPI.Controllers
{
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
            var token = SsoJwtManager.Instance.GetAccessToken(Request);
            User = SsoJwtManager.Instance.GetPrincipal(token);

            // Read the Request Principal (User), and grab the userName claim.
            var username = SsoJwtManager.Instance.GetClaimValue(this.User, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(this.User, "password");

            // Proccess any other information.

            // Create User???
            // TODO: @Scott There is a serious problem about entering Users with a registration that is incomplete.
            // Maybe set them to an unregistered User?

            // Set some sort of flag up for the User in DB.
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, password, false);
            var account = new Account()
            {
                UserName = username,
                // TODO: @Scott Get rid of the email somehow.
                Email = "aaa@aaa.net",
                Password = hashedPassword,
                // TODO: @Scott The suspension time is set because exception is thrown trying to convert DateTime2 to DateTime???
                SuspensionTime = DateTime.UtcNow,
                AccountStatus = true,
                FirstTimeUser = true,
            };
            _accountRepository.Insert(account);

            var salt = new Salt()
            {
                PasswordSalt = passwordSalt,
                UserName = username
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
            var requestAccessToken = SsoJwtManager.Instance.GetAccessToken(Request);
            User = SsoJwtManager.Instance.GetPrincipal(requestAccessToken);

            // Read the Request Principal (User), and grab the userName claim.
            var username = SsoJwtManager.Instance.GetClaimValue(this.User, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(this.User, "password");

            // Get the password salt by username.
            var saltModel = _saltRepository.GetSingle(model => model.UserName == username);
            var salt = saltModel.PasswordSalt;
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(salt, password, true);

            // Does the Password check out?
            var account = _accountRepository.GetSingle(acc => acc.UserName == username);
            if (!account.Password.Equals(hashedPassword))
            {
                return Unauthorized();
            }

            // Set current account token to expired list.
            var accountAccessToken = _jwtAccessTokenRepository.GetSingle(oldToken => oldToken.UserName == username);
            var deadToken = new ExpiredAccessToken
            {
                ExpiredTokenValue = accountAccessToken.Value
            };
            _expiredAccessTokenRepository.Insert(deadToken);

            // Generate new token based on username and available claims.
            // TODO: @Scott Sso Login needs to generate a token with a username AND list of claims.
            var claimList = new SortedList
            {
                {"scott", "roberts"}
            };

            //var tokenTest = SsoJwtManager.Instance.TestGenerateToken(claimList, username);
            var token = JwtManager.Instance.GenerateToken(username);
            accountAccessToken.Value = token;

            // Store updated account token in DB.
            _jwtAccessTokenRepository.Update(accountAccessToken);


            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/Sso/Login?accesstoken=" + token));
        }

        // TODO: @Scott Start working on the Login Get Request
        [HttpGet]
        public IHttpActionResult Login([FromUri] string accessToken)
        {
            User = SsoJwtManager.Instance.GetPrincipal(accessToken);

            // This will be the controller that returns the homepage with the user logged in to our app.
            return Ok(accessToken);
        }

        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            var requestAccessToken = SsoJwtManager.Instance.GetAccessToken(Request);
            User = SsoJwtManager.Instance.GetPrincipal(requestAccessToken);

            // Retrieve username
            var username = SsoJwtManager.Instance.GetClaimValue(User, "username");
            
            // Get related account from username
            var account = _accountRepository.GetSingle(acc => acc.UserName == username);

            // Retrieve password, create salt, create salted password
            var password = SsoJwtManager.Instance.GetClaimValue(User, "password");
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, password, true);

            // Update password for account
            account.Password = hashedPassword;
            _accountRepository.Update(account);

            // Update salt table related to account
            var saltModel = _saltRepository.GetSingle(model => model.UserName == username);
            saltModel.PasswordSalt = passwordSalt;
            _saltRepository.Update(saltModel);
           
            return Ok();
        }
    }
}