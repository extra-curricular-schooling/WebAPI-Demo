using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using ECS.WebAPI.Filters.AuthenticationFilters;
using System;
using System.Net;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;

namespace ECS.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET,POST")]
    [AuthenticateSsoAccessToken]
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
            // Get the Token
            var token = SsoJwtManager.Instance.GetJwtFromAuthorizationHeader(Request);

            // Read the JWT, and grab the userName claim.
            var userName = SsoJwtManager.Instance.GetClaimValue(token, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(token, "password");

            // Proccess any other information.

            // Create User???
            // TODO: @Scott There is a serious problem about entering Users with a registration that is incomplete.
            // Maybe set them to an unregistered User?

            // Set some sort of flag up for the User in DB.
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var account = new Account()
            {
                UserName = userName,
                // TODO: @Scott Get rid of the email somehow.
                Email = "datemail@csulb.net",
                Password = HashService.Instance.HashPasswordWithSalt(passwordSalt, password),
                // TODO: @Scott The suspension time is set because exception is thrown trying to convert DateTime2 to DateTime???
                SuspensionTime = DateTime.UtcNow,
                AccountStatus = true,
                FirstTimeUser = true,
            };
            _accountRepository.Insert(account);

            var salt = new Salt()
            {
                PasswordSalt = passwordSalt,
                UserName = userName
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
            // Get the Token
            var token = SsoJwtManager.Instance.GetJwtFromAuthorizationHeader(Request);

            // Read the JWT, and grab the userName claim.
            var username = SsoJwtManager.Instance.GetClaimValue(token, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(token, "password");

            // TODO: @Scooter Get the salt repository able to grab salt by username.
            var saltModel = _saltRepository.GetSaltByUsername(username);
            var salt = saltModel.PasswordSalt;
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(salt, password);

            if (!_accountRepository.GetById(username).Password.Equals(hashedPassword))
            {
                return Unauthorized();
            }

            // Set old token to expired list.
            var oldAccessToken = _jwtAccessTokenRepository.GetById(username);
            var deadToken = new ExpiredAccessToken
            {
                ExpiredTokenValue = oldAccessToken.Value
            };
            _expiredAccessTokenRepository.Insert(deadToken);

            // Store JWT in DB.
            // WHY IS THIS CONNECTED TO A USER AND NOT AN ACCOUNT???
            var tokenModel = new JAccessToken
            {
                UserName = username,
                Value = token
            };
            _jwtAccessTokenRepository.Update(tokenModel);

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/#/Home"));
        }

        // TODO: @Scott Start working on the Login Get Request
        [HttpGet]
        public IHttpActionResult Login([FromUri] string accessToken)
        {
            // This will be the controller that returns the homepage with the user logged in to our app.
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            // Get the Token
            var token = SsoJwtManager.Instance.GetJwtFromAuthorizationHeader(Request);

            // Retrieve username
            var username = SsoJwtManager.Instance.GetClaimValue(token, "username");
            
            // Get related account from username
            var account = _accountRepository.GetById(username);

            // Retrieve password, create salt, create salted password
            var password = SsoJwtManager.Instance.GetClaimValue(token, "password");
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, password);

            // Update password for account
            account.Password = hashedPassword;
            _accountRepository.Update(account);

            // Update salt table related to account
            var saltModel = _saltRepository.GetSaltByUsername(username);
            saltModel.PasswordSalt = passwordSalt;
            _saltRepository.Update(saltModel);
           
            return Ok();
        }
    }
}