using ECS.DTO;
using System.Web.Http;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("SSO")]
    public class SSOController : ApiController
    {
        //[Ajax, Json]
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register([FromBody] SSOAccountRegistrationDTO ssoAccount)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(ssoAccount);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.

            // Return successful response
            return Ok();

        }
        

        [HttpPost]
        [Route("ResetPassword")]
        public IHttpActionResult ResetPassword([FromBody] AccountCredentialsDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // We need to push this information to the database.
            //using(var context = new ECSContext())

            // Return successful response?
            return Ok();

        }
    }
}