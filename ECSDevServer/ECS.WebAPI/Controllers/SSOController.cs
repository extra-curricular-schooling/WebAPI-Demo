using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using ECS.WebAPI.Filters.AuthenticationFilters;
using System;
using System.Net;
using ECS.WebAPI.Services.Security.AccessTokens.Jwt;
using ECS.WebAPI.Services.Security.Hash;

namespace ECS.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET,POST")]
    [AuthenticateSsoAccessToken]
    //[AuthorizeSsoAccessToken]
    public class SsoController : ApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJAccessTokenRepository _jwtAccessTokenRepository;
        private readonly ISaltRepository _saltRepository;

        public SsoController()
        {
            _accountRepository = new AccountRepository();
            _jwtAccessTokenRepository = new JAccessTokenRepository();
            _saltRepository = new SaltRepository();
        }
        public SsoController(IAccountRepository accountRepo, IJAccessTokenRepository jwtRepo, ISaltRepository saltRepo)
        {
            _accountRepository = accountRepo;
            _jwtAccessTokenRepository = jwtRepo;
            _saltRepository = saltRepo;
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
            // call the transformer
            var token = SsoJwtManager.Instance.GetJwtFromAuthorizationHeader(Request);
            // Read the JWT, and grab the userName claim.
            var userName = SsoJwtManager.Instance.GetUsername(token);
            var password = SsoJwtManager.Instance.GetPassword(token);
            // Proccess any other information.

            // Set some sort of flag up for the User in DB.
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var account = new Account()
            {
                UserName = userName,
                Email = "datemail@csulb.net",
                Password = HashService.Instance.HashPasswordWithSalt(passwordSalt, password),
                AccountStatus = true,
                SuspensionTime = DateTime.Now,
                //RoleType = roleType,
                FirstTimeUser = true,
            };
            _accountRepository.Insert(account);

            var salty = new Salt()
            {
                PasswordSalt = passwordSalt,
                UserName = userName
            };
            _saltRepository.Insert(salty);

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
            var token = SsoJwtManager.Instance.GetJwtFromAuthorizationHeader(Request);
            // Read the JWT, and grab the claims.
            var userName = SsoJwtManager.Instance.GetUsername(token);

            // Proccess any other information.

            // Should we make an AccountDTO for this and make a repository for that???
            // Account account = accountRepository.GetById(userName);
            var thing = _accountRepository.SearchFor(x => x.UserName == "test1");

            // Check if the User is a firstTimeUser
            //if (account.UserName != null)
            //{
            //    return Ok("Repo works");
            //    //RedirectToRoute("Registration/PartialRegistration", account);
            //}

            // Store JWT in DB.
            // WHY IS THIS CONNECTED TO A USER AND NOT AN ACCOUNT???
            var tokenModel = new JAccessToken
            {
                UserName = userName,
                Value = token
            };
            //jwtRepository.Update(tokenModel);

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/#/Home"));
        }

        [HttpPost]
        public IHttpActionResult ResetPassword()
        {
            // Transform Sso JWT into useful JWT

            // Check if user exists

            // If so... Hash and salt password
            // And Save hashed password and salt in the appropriate tables.
            return Ok();
        }
    }
}