using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using ECS.WebAPI.Filters.AuthenticationFilters;
using System;
using System.Net;
using ECS.WebAPI.Services.Security.AccessTokens.Jwt;
using ECS.WebAPI.Services.Security.Hash;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET,POST")]
    [AuthenticateSsoAccessToken]
    //[AuthorizeSsoAccessToken]
    public class SsoController : ApiController
    {
        private readonly IAccountRepository accountRepository;
        private readonly IJAccessTokenRepository jwtAccessTokenRepository;
        private readonly ISaltRepository saltRepository;

        public SsoController()
        {
            accountRepository = new AccountRepository();
            jwtAccessTokenRepository = new JAccessTokenRepository();
            saltRepository = new SaltRepository();
        }
        public SsoController(IAccountRepository accountRepo, IJAccessTokenRepository jwtRepo, ISaltRepository saltRepo)
        {
            accountRepository = accountRepo;
            jwtAccessTokenRepository = jwtRepo;
            saltRepository = saltRepo;
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
            var salt = HashService.Instance.CreateSaltKey();
            Account account = new Account()
            {
                UserName = userName,
                Email = "datemail@csulb.net",
                Password = HashService.Instance.HashPasswordWithSalt(salt, password),
                AccountStatus = true,
                SuspensionTime = DateTime.Now,
                //RoleType = roleType,
                FirstTimeUser = true,
            };

            Salt salty = new Salt()
            {
                PasswordSalt = salt,
                UserName = userName
            };
       
            accountRepository.Insert(account);
            saltRepository.Insert(salty);
            return Ok();
        }

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
            var thing = accountRepository.SearchFor(x => x.UserName == "test1");

            // Check if the User is a firstTimeUser
            //if (account.UserName != null)
            //{
            //    return Ok("Repo works");
            //    //RedirectToRoute("Registration/PartialRegistration", account);
            //}

            // Store JWT in DB.
            // WHY IS THIS CONNECTED TO A USER AND NOT AN ACCOUNT???
            JAccessToken tokenModel = new JAccessToken
            {
                UserName = userName,
                Value = token,
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