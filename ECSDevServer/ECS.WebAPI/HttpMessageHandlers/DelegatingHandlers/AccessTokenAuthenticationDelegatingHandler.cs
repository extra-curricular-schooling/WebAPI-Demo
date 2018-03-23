using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ECS.Models;
using ECS.Repositories;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    public class AccessTokenAuthenticationDelegatingHandler: DelegatingHandler
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;

        public AccessTokenAuthenticationDelegatingHandler()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();

            // 1. Look for credentials in the request.
            var authHeader = request.Headers.Authorization;
            var unauthorizedResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized
            };

            // 2. The request has have a "Bearer" request to process
            if (authHeader == null || authHeader.Scheme != "Bearer")
            {
                return tsc.Task;
            }
                
            // 3. If the credentials are malformed, set the error result.
            var token = authHeader.Parameter;

            if (string.IsNullOrEmpty(token))
            {
                unauthorizedResponse.ReasonPhrase = "Empty Token";
                tsc.SetResult(unauthorizedResponse);
                return tsc.Task;
            }

            // TODO: @Scott Will they always have just a one-time token here? Could be a good place to start adding some hook ins.

            // 4. Check the database for a reuse of expired tokens.
            var expiredAccessToken = _expiredAccessTokenRepository.GetSingle(expiredToken => expiredToken.ExpiredTokenValue == token );
            if (expiredAccessToken != null && !expiredAccessToken.CanReuse)
            {
                unauthorizedResponse.ReasonPhrase = "Replay token";
                tsc.SetResult(unauthorizedResponse);
                return tsc.Task;
            }
            // The token can only be reused once for the login
            if (expiredAccessToken != null && expiredAccessToken.CanReuse)
            {
                expiredAccessToken.CanReuse = false;
                _expiredAccessTokenRepository.Update(expiredAccessToken);
            }

            if (expiredAccessToken == null)
            {
                // 5. Insert One time token so no one else uses it.
                _expiredAccessTokenRepository.Insert(new ExpiredAccessToken
                {
                    ExpiredTokenValue = token,
                    CanReuse = true
                });
            }
            
            // 6. Finally check if the token is validated and returns a principal.
            IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);
            if (principal == null)
            {
                unauthorizedResponse.ReasonPhrase = "Invalid Principal";
                tsc.SetResult(unauthorizedResponse);
                return tsc.Task;
            }

            // 7. Authentication was successful, set the principal to notify other filters that
            // the request is authenticated.
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;

            return base.SendAsync(request, cancellationToken);
        }
    }
}