using ECS.DTO;
using ECS.WebAPI.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    public class SsoController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public void Registration()
        {
            // Return a Registration form if they haven't properly finished registration??
        }

        /*
         * When Web API encounters a type implementing this interface as result of an 
         * executed action, instead of running content negotiation, it will call 
         * its only method (Execute) to produce the HttpResponseMessage, and then use that to 
         * respond to the client
         */
        [HttpPost]
        public IHttpActionResult Registration(SsoRegistrationDTO ssoAccount)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(ssoAccount);

            if (ModelState.IsValid)
            {
                // Make custom validator object.

                // Set some sort of flag up for the User in DB.
                // When they try and register in our app after SSO's registration, check the flag.

                // Return successful response
                return Ok("Post Registration");
            }

            // Code errors for specific html states.

            // Error handling in controller: https://stackoverflow.com/questions/10732644/best-practice-to-return-errors-in-asp-net-web-api#10734690

            // Fail-safe return
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IHttpActionResult SecurityQuestions()
        {
            // Grab the repository information for User's security questions
            
            // Return List<SecurityQuestionDTO> to the Client
            return Ok("Get Security Questions");
        }

        [HttpPost]
        public IHttpActionResult SecurityQuestions(AccountCredentialDTO credentials)
        {
            // Check the db If their answers are correct.
            return Ok("Post Security Questions");
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult ResetPassword([FromBody] AccountCredentialDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (ModelState.IsValid)
            {
                // We need to take this information and update the user's password in the db.
                // using(var context = new ECSContext())

                // Return 200
                return Ok("Post Reset Password");
            }

            // Fail state
            return BadRequest(ModelState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult Login([FromBody] AccountCredentialDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (ModelState.IsValid)
            {
                // Proccess any other information.

                // Check app DB for user.

                // Issue login information

                // Return 200
                return Ok(credentials);
            }

            // Fail state
            return BadRequest(ModelState);


            // Return successful response with a "redirect" to where the token will be given
            // Post methods should not return data, but should return responses and location headers of 
            // what was created in the post.

            //return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    }
}