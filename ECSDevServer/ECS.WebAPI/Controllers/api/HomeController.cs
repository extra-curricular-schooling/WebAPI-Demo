using ECS.WebAPI.Filters;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    public class HomeController : ApiController
    {

    }
}