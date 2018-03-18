using ECS.WebAPI.Services.Security.AccessTokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    // https://stackoverflow.com/questions/22587992/jwt-and-web-api-jwtauthforwebapi-looking-for-an-example
    // NOT WORKING YET!!!!!
    public class JwtAccessTokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;

            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
            {
                // missing authorization header
                return base.SendAsync(request, cancellationToken);
            }

            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
            }

            try
            {
                var username = SsoJwtHelper.Instance.GetUsernameFromToken(token);
                IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
        }
    }
}