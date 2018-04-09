using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ECS.WebAPI.Filters.ExceptionFilters
{
    // This is an example of a Exception filter we can put at the global, controller, or action levels.
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContextcontext)
        {
            if (actionExecutedContextcontext.Exception is NotImplementedException)
            {
                actionExecutedContextcontext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}