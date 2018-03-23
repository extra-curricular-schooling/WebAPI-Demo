using ECS.WebAPI.Filters;
using System.Web.Http;
using ECS.WebAPI.Filters.AuthorizationFilters;
using System.Web.Http.Cors;
using ECS.Repositories;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("Home")]
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    public class HomeController : ApiController
    {
        //private readonly IArticleRepository articleRepository;
        //private readonly IInterestTagRepository interestTagRepository;
        //private readonly IAccountRepository accountRepository;
        
        [HttpPost]
        [Route("Articles")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult GetArticles(string username)
        {
            // TODO: @Hugo Get interest tags based on username
            // TODO: @Hugo Get Articles based on Interest Tags
            // TODO: @Hugo Return article interest Tags, title, description, link
            return Ok();

        }
    }
}