using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ECS.WebAPI.Filters.AuthorizationFilters
{
    // Source: https://blogs.msdn.microsoft.com/carlosfigueira/2012/03/09/implementing-requirehttps-with-asp-net-web-api/
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                HttpResponseMessage response;
                var uri = new UriBuilder(request.RequestUri)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = 443
                };
                var body = string.Format("The resource can be found at: {0}", uri.Uri.AbsoluteUri);
                if (request.Method.Equals(HttpMethod.Get) || request.Method.Equals(HttpMethod.Head))
                {
                    response = request.CreateResponse(HttpStatusCode.Found);
                    response.Headers.Location = uri.Uri;
                    if (request.Method.Equals(HttpMethod.Get))
                    {
                        response.Content = new StringContent(body);
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound);
                    response.Content = new StringContent(body);
                }
                actionContext.Response = response;
            }
        }
    }
}