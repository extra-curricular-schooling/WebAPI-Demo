using ECS.DTO;
using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult SubmitLogin([FromBody] AccountCredentialsDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.

            // Check app DB for user.

            // Issue login information

            return Ok();

            // Return successful response with a "redirect" to where the token will be given
            // Post methods should not return data, but should return responses and location headers of 
            // what was created in the post.

            //return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    }
}