using ECS.DTO;
using ECS.WebAPI.Services;
using Newtonsoft.Json;
using System.Net;
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
        public IHttpActionResult Register()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var partialUserAccount = JsonConvert.DeserializeObject<SSOAccountRegistrationDTO>(json);

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.

            // Return successful response
            return Ok();

        }
        //[Ajax, Json]
        [HttpPost]
        [Route("ResetPassword")]
        public IHttpActionResult ResetPassword() // I need the equivalent of [FromBody] to use for incoming JSON
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var partialUserAccount = JsonConvert.DeserializeObject<SSOAccountRegistrationDTO>(json);

            // We need to push this information to the database.
            //using(var context = new ECSContext())

            // Return successful response?
            return Ok();

        }
    }
}