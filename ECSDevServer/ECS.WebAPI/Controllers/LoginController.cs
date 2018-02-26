using ECS.DTO;
using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult PostLogin([FromBody] AccountCredentialsDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.

            // Check app DB for user.

            // Issue login information

            // Return successful response
            return Ok(credentials);
        }
    }
}