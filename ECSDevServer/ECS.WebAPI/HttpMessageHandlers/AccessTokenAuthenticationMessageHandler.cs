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
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;

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
                // Insert One time token
                _expiredAccessTokenRepository.Insert(new ExpiredAccessToken
                {
                    Token = token
                });

                // 5. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                try
                {
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