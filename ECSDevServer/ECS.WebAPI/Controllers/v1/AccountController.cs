using System.Web.Http;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    public class AccountController : ApiController
    {
        // Should this encompass all of the Account related Action Methods:
        // Edit Personal Information
        // Edit Tag information
        // Change Password
        // View Points
        // See time remaining for suspension
    }
}