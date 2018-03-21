using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers
{
    public class AccessTokenAuthenticationMessageHandler : HttpMessageHandler
    {
        private IExpiredAccessTokenRepository _expiredAccessTokenRepository;

        public AccessTokenAuthenticationMessageHandler()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();

            // 1. Look for credentials in the request.
            var authHeader = request.Headers.Authorization;

            // 2. The request has have a "Bearer" request to process
            if (authHeader == null || authHeader.Scheme != "Bearer")
            {
                return tsc.Task;
            }
                
            // 3. If the credentials are malformed, set the error result.
            var token = authHeader.Parameter;
            if (string.IsNullOrEmpty(token) || _expiredAccessTokenRepository.GetById(token) != null)
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Bad Token"
                };
                tsc.SetResult(response);
            }
            else
            {
                // TODO: @Scott The expired access token insert is causing a EntityValidationError. Fix
                // The problem is that the token is longer than 128 characters? Doesn't seem right but ok...
                // Insert One time token
                _expiredAccessTokenRepository.Insert(new ExpiredAccessToken
                {
                    ExpiredTokenValue = token
                });

                // 5. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                try
                {
                    // TODO: @Scott SsoJwtManager is the only dependency from making this generic.
                    // Need to figure out how to validate and get token.
                    IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);
                    Thread.CurrentPrincipal = principal;
                    request.GetRequestContext().Principal = principal;
                }
                catch (Exception)
                {
                    var response = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        ReasonPhrase = "Principal Error"
                    };
                    tsc.SetResult(response);
                }
            }
            return tsc.Task;
        }
    }
}