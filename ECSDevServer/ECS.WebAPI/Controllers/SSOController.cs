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
        private readonly ITokenRepository tokenRepository;

        public SsoController()
        {
            accountRepository = new AccountRepository();
            tokenRepository = new TokenRepository();
        }
        public SsoController(IAccountRepository repo)
        {
            accountRepository = repo;
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
        [SsoAuthorize]
        public IHttpActionResult Login()
        {
            var token = JwtHelper.Instance.GetJwtFromAuthorizationHeader(Request);
            // Read the JWT, and grab the claims.
            var username = JwtHelper.Instance.GetUsernameFromToken(token);

            // Proccess any other information.

            // Store JWT in DB.
            // WHY IS THIS CONNECTED TO A USER AND NOT AN ACCOUNT???
            Token tokenModel = new Token
            {
                Name = "jwt",
                Username = username,
                Value = token
            };
            tokenRepository.Update(tokenModel);

            // Redirect them to our Home page with their credentials logged.
            return Content(HttpStatusCode.Redirect, new Uri("https://localhost:44311/#/Home"));
        }
    }
}