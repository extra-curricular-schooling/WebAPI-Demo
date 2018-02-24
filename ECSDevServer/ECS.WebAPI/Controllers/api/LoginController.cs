using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult PostLogin()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var credentials = JsonConverterService.DeserializeObject<AccountCredentialsDTO>(json);

            // Proccess any other information.

            // Check app DB for user.

            // Issue login information

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}