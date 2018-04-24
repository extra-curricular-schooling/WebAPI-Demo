using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ECS.Constants.Security;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    public class SsoAccessTokenAuthenticationDelegatingHandler: DelegatingHandler
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;
        private readonly IBadAccessTokenRepository _badAccessTokenRepository;

        public SsoAccessTokenAuthenticationDelegatingHandler()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
            _badAccessTokenRepository = new BadAccessTokenRepository();
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

            // Data Access
            try
            {
                var badTokenModel = _badAccessTokenRepository.GetSingle(badToken => badToken.BadTokenValue == token);
                var expiredTokenModel = _expiredAccessTokenRepository.GetSingle(expiredToken => expiredToken.ExpiredTokenValue == token);

                // Check the Bad Tokens to ensure this hasn't been seen before.
                if (badTokenModel != null)
                {
                    return SendError(tsc, "Malformed Token");
                }

                // 4. Check the database for a reuse of expired tokens.
                if (expiredTokenModel != null)
                {
                    if (expiredTokenModel.CanReuse)
                    {
                        expiredTokenModel.CanReuse = false;
                        // TODO: @Team This breaks when explicitly setting entity.state in repository.
                        _expiredAccessTokenRepository.Update(expiredTokenModel);
                    }
                    else
                    {
                        return SendError(tsc, "Expired Token");
                    }
                }
                else
                {
                    // Insert One time token so no one else uses it.
                    _expiredAccessTokenRepository.Insert(new ExpiredAccessToken(token, true));
                }
            }
            catch (Exception e)
            {
                return SendError(tsc, e.Message);
            }

            // Validate Token
            try
            {
                // Validate and Set principal
                IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);

                // 
                if (!HasAcceptedClaims(principal))
                {
                    _expiredAccessTokenRepository.Insert(new ExpiredAccessToken(token, false));
                    return SendError(tsc, "Required claims not present.");
                }

                // 7. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
            catch (Exception e)
            {
                // Throw token into bad tokens.
                if (!_badAccessTokenRepository.Exists(badToken => badToken.BadTokenValue == token))
                    _badAccessTokenRepository.Insert(new BadAccessToken(token));
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
                StatusCode = HttpStatusCode.Unauthorized
            };

            tsc.SetResult(unauthorizedResponse);

            return tsc.Task;
        }
    }
}