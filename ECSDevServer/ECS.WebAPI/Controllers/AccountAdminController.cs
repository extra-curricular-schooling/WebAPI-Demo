using ECS.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("AccountAdmin")]
    public class AccountAdminController : ApiController
    {
        // Edit other account information
        // ... look at scope document

        [HttpGet]
        [EnableCors("http://localhost:8080", "*", "GET")]
        public IHttpActionResult AccountInformation()
        {
            return Ok("Get Account Information");
        }

        [HttpPost]
        [EnableCors("http://localhost:8080", "*", "POST")]
        public IHttpActionResult AccountInformation(Account account)
        {
            // Check model binding

            // Update info in database.

            // Return successful response if update correctly.
            return Ok("Post Account Information");
        }

        [HttpGet]
        [EnableCors("http://localhost:8080", "*", "GET")]
        public IHttpActionResult AccountStatus()
        {
            return Ok("Get Account Status");
        }

        [HttpPost]
        [EnableCors("http://localhost:8080", "*", "POST")]
        public IHttpActionResult AccountStatus(Account account)
        {
            // Check model binding

            // Update points in database.

            // Return successful response if update correctly.
            return Ok("Post Scholar Points");
        }
    }
}