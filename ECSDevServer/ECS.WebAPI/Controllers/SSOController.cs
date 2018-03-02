using ECS.DTO;
using System.Web.Http;
using System.Web.Http.Cors;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    public class SSOController : ApiController
    {
        /*
         * When Web API encounters a type implementing this interface as result of an 
         * executed action, instead of running content negotiation, it will call 
         * its only method (Execute) to produce the HttpResponseMessage, and then use that to 
         * respond to the client
         */
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult Registration(SSOAccountRegistrationDTO ssoAccount)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(ssoAccount);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Make custom validator object.

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.

            // Return successful response
            return Ok();

        }

        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult ResetPassword([FromBody] AccountCredentialsDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // We need to take this information and update the user's password in the db.
            //using(var context = new ECSContext())

            // Return successful response?
            return Ok();
        }
    }
}