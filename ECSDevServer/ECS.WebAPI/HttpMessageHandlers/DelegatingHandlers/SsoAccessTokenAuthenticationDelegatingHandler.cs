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
                if (!HasAcceptedClaims(principal))
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

        private bool HasAcceptedClaims(IPrincipal principal)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var usernameClaim = SsoJwtManager.Instance.GetClaim(principal, "username");
            var passwordClaim = SsoJwtManager.Instance.GetClaim(principal, "password");
            var issuedAtClaim = SsoJwtManager.Instance.GetClaim(principal, "iat");
            var applicationClaim = SsoJwtManager.Instance.GetClaim(principal, "application");
            var applicationClaimValue = applicationClaim.Value.ToLower();
            var isCorrectApp = applicationClaimValue.Equals(ClaimValues.Ecs);

            return usernameClaim != null && passwordClaim != null &&
                   issuedAtClaim != null && isCorrectApp;
        }

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