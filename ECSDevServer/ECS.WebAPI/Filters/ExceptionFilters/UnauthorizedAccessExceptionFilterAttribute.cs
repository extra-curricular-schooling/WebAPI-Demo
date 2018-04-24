using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ECS.WebAPI.Filters.ExceptionFilters
{
    public class UnauthorizedAccessExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}