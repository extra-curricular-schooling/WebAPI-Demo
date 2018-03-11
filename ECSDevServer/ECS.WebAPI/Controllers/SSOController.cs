using ECS.DTO;
using ECS.WebAPI.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using System.Net;
using System.Diagnostics;
using System.Security.Claims;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    public class SsoController : ApiController
    {
        private readonly IAccountRepository accountRepository;

        public SsoController()
        {
            accountRepository = new AccountRepository();
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
        public IHttpActionResult Registration()
        {
            // Validate JWT? Make custom validator object?

            // Read the JWT, and grab the information out of it.

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.
            Account account = new Account();
            //accountRepository.Insert(account);

            // Code errors for specific html states.
            // Error handling in controller: https://stackoverflow.com/questions/10732644/best-practice-to-return-errors-in-asp-net-web-api#10734690

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult Login()
        {
            var tokens = JwtManager.GetJwtsFromHttpHeaders(Request);
            // Authenticate JWT? Make custom validator object?
            foreach (var token in tokens)
            {
                var principal = JwtManager.GetPrincipal(token);
                if (null != principal)
                {
                    foreach (Claim claim in principal.Claims)
                    {
                        Debug.Write("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
                    }
                }
            }

            // Read the JWT, and grab the information out of it.

            // Proccess any other information.

            // Check app DB for user.

            // Issue login information
            return Ok();
        }
    }
}