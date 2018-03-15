using ECS.WebAPI.Services;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using ECS.WebAPI.Filters.AuthorizationFilters;
using System;
using ECS.WebAPI.Services.Security;
using System.Net;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    public class SsoController : ApiController
    {
        private readonly IAccountRepository accountRepository;
        private readonly IJwtRepository jwtRepository;

        public SsoController()
        {
            accountRepository = new AccountRepository();
            jwtRepository = new JwtRepository();
        }
        public SsoController(IAccountRepository accountRepo, IJwtRepository jwtRepo)
        {
            accountRepository = accountRepo;
            jwtRepository = jwtRepo;
        }

        /*
         * When Web API encounters a type implementing this interface as result of an 
         * executed action, instead of running content negotiation, it will call 
         * its only method (Execute) to produce the HttpResponseMessage, and then use that to 
         * respond to the client
         */
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        [SsoAuthorize]
        public IHttpActionResult Registration()
        {
            var token = JwtHelper.Instance.GetJwtFromAuthorizationHeader(Request);
            // Read the JWT, and grab the claims.
            var username = JwtHelper.Instance.GetUsernameFromToken(token);

            // Proccess any other information.

            // Set some sort of flag up for the User in DB.

            // When they try and register in our app after SSO's registration, check the flag.

            Account account = new Account();
            //accountRepository.Insert(account);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        //[SsoAuthorize]
        public IHttpActionResult Login()
        {
            var token = JwtHelper.Instance.GetJwtFromAuthorizationHeader(Request);
            // Read the JWT, and grab the claims.
            var username = JwtHelper.Instance.GetUsernameFromToken(token);

            // Proccess any other information.

            // Should we make an AccountDTO for this and make a repository for that???
            // Account account = accountRepository.GetById(username);
            var thing = accountRepository.SearchFor(x => x.UserName == "test1");

            // Check if the User is a firstTimeUser
            //if (account.UserName != null)
            //{
            //    return Ok("Repo works");
            //    //RedirectToRoute("Registration/PartialRegistration", account);
            //}

            // Store JWT in DB.
            // WHY IS THIS CONNECTED TO A USER AND NOT AN ACCOUNT???
            JWT tokenModel = new JWT
            {
                UserName = username,
                Value = token
            };
            jwtRepository.Update(tokenModel);

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/#/Home"));
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        //[SsoAuthorize]
        public IHttpActionResult ResetPassword()
        {
            return Ok();
        }
    }
}