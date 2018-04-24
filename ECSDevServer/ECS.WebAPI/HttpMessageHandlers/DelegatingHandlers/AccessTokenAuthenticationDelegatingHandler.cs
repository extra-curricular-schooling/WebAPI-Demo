using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    public class AccessTokenAuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;
        private readonly IBadAccessTokenRepository _badAccessTokenRepository;

        public AccessTokenAuthenticationDelegatingHandler()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
            _badAccessTokenRepository = new BadAccessTokenRepository();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();

            // 1. Look for credentials in the request.
            var authHeader = request.Headers.Authorization;

            // Might have to check the request route to see if it is SSO, if so return base.SendAsync(request, cancellationToken)

            var isSSO = request.GetRouteData();


            
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

            // Check the Bad Tokens to ensure this hasn't been seen before.
            if (_badAccessTokenRepository.Exists(badToken => badToken.BadTokenValue == token))
            {
                return SendError(tsc, "Malformed Token");
            }

            // 4. Check the database for a reuse of expired tokens.
            var expiredAccessToken = _expiredAccessTokenRepository.GetSingle(expiredToken => expiredToken.ExpiredTokenValue == token);

            if (expiredAccessToken != null)
            {
                if (expiredAccessToken.CanReuse)
                {
                    expiredAccessToken.CanReuse = false;
                    _expiredAccessTokenRepository.Update(expiredAccessToken);
                }
                else
                {
                    return SendError(tsc, "Expired Token");
                }
            }

            try
            {
                // 6. Finally check if the token is validated and returns a principal.
                IPrincipal principal = JwtManager.Instance.GetPrincipal(token);
                if (!HasAcceptedClaims(principal))
                {
                    throw new Exception("Required Claims not Present");
                }

                // 7. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;


            }
            catch (Exception e)
            {
                _badAccessTokenRepository.Insert(new BadAccessToken(token));
                return SendError(tsc, e.Message);
            }
            return base.SendAsync(request, cancellationToken);
        }

        private bool HasAcceptedClaims(IPrincipal principal)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var usernameClaim = JwtManager.Instance.GetClaim(principal, "username");
            var passwordClaim = JwtManager.Instance.GetClaim(principal, "password");
            var expiredAtClaim = JwtManager.Instance.GetClaim(principal, "exp");

            return usernameClaim != null && passwordClaim != null &&
                   expiredAtClaim != null;
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
