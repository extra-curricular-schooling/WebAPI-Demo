using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ECS.WebAPI.Filters.ExceptionFilters
{
    /// <summary>
    /// Filter used as a catch-all in case any revealing exceptions start to escape.
    /// </summary>
    public class AnyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var response = actionExecutedContext.Response;
                switch (actionExecutedContext.Exception)
                {
                    case NotImplementedException e:
                        response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                        break;
                    case UnauthorizedAccessException e:
                        response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        break;
                    default:
                        response = new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            Content = new StringContent(actionExecutedContext.Exception.Message)
                        };
                        break;
                }
                actionExecutedContext.Exception = null;
            }
        }
    }
}