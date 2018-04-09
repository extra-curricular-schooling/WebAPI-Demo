using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ECS.WebAPI.Filters.ExceptionFilters
{
    public class SqlExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is SqlException)
            {
                actionExecutedContext.Response =
                    new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent("Sql Error")
                    };
            }
        }
    }
}