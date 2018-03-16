using ECS.DTO;
using ECS.WebAPI.Filters;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECS.WebAPI.Controllers
{
    [RequireHttps]
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("SubmitLogin")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult SubmitLogin(AccountCredentialDTO credentials)
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