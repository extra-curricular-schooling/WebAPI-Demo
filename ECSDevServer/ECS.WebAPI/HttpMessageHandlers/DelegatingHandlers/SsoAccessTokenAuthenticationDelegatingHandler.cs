using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ECS.BusinessLogic.Services;
using ECS.BusinessLogic.Services.Implementations;
using ECS.Constants.Security;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    public class SsoAccessTokenAuthenticationDelegatingHandler: DelegatingHandler
    {
        private readonly AuthenticationService _authenticationService;

        public SsoAccessTokenAuthenticationDelegatingHandler()
        {
            _authenticationService = new AuthenticationService();
        }

        /// <summary>
        /// Pipeline injection for Sso Authentication
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task Response Message</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();

            // 1. Look for credentials in the request.
            var authHeader = request.Headers.Authorization;
            
            // 2. The request has have a "Bearer" request to process
            if (authHeader == null || authHeader.Scheme != "Bearer")
            {
                return base.SendAsync(request, cancellationToken);
            }

            // Token Value
            var token = authHeader.Parameter;
            if (token == null)
            {
                return SendError(tsc, "Empty Token");
            }

            // Data Access Token Checking.
            try
            {
                _authenticationService.CheckBadAccessTokens(token);
                _authenticationService.CheckExpiredAccessTokens(token, 1);

                // TODO: @Scott Make custom error type to not have two different try catch blocks.
            }
            catch (Exception e)
            {
                return SendError(tsc, e.Message);
            }

            // Validate Token
            try
            {
                IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);

                // Check if Claims exist
                if (!SsoJwtManager.Instance.HasAcceptedClaims(principal))
                {
                    return SendError(tsc, "Required claims not present.");
                }

                _authenticationService.InsertExpiredAccessToken(token, false);

                // 7. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
            catch (Exception e)
            {
                // Throw token into bad tokens if not validated.
                _authenticationService.InsertBadAccessToken(token);
                return SendError(tsc, e.Message);
            }

            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Catches any Exceptions or Errors occurring in TokenAuthenticatingDelegatingHandler and sends unauthorized response.
        /// </summary>
        /// <param name="tsc"></param>
        /// <param name="errorMessage"></param>
        /// <returns>Error Task Message</returns>
        private Task<HttpResponseMessage> SendError(TaskCompletionSource<HttpResponseMessage> tsc, string errorMessage)
        {
            var unauthorizedResponse = new HttpResponseMessage
            {
                Content = new StringContent(errorMessage),
                StatusCode = HttpStatusCode.Unauthorized
            };

            tsc.SetResult(unauthorizedResponse);

            return tsc.Task;
        }
    }
}