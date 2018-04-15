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
                return tsc.Task;
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
                

            // TODO: @Scott Will they always have just a one-time token here? Could be a good place to start adding some hook ins.
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
                IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);
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
                _badAccessTokenRepository.Insert(new BadAccessToken
                {
                    BadTokenValue = token
                });
                return SendError(tsc, e.Message);
            }

            // TODO: @Scott Please uncomment the inserting expired token when ready to deploy. It is annoying to test with.
            // Insert One time token so no one else uses it.
            //_expiredAccessTokenRepository.Insert(new ExpiredAccessToken
            //{
            //    ExpiredTokenValue = token,
            //    CanReuse = true
            //});



            return base.SendAsync(request, cancellationToken);
        }

        private bool HasAcceptedClaims(IPrincipal principal)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var usernameClaim = SsoJwtManager.Instance.GetClaim(principal, "username");
            var passwordClaim = SsoJwtManager.Instance.GetClaim(principal, "password");
            var issuedAtClaim = SsoJwtManager.Instance.GetClaim(principal, "iat");
            var applicationClaim = SsoJwtManager.Instance.GetClaim(principal, "application");

            return usernameClaim != null && passwordClaim != null &&
                   issuedAtClaim != null && applicationClaim != null;
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