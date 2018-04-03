using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using ECS.Models;
using ECS.Repositories;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers
{
    public class SsoAccessTokenAuthenticationDelegatingHandler: DelegatingHandler
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;

        public SsoAccessTokenAuthenticationDelegatingHandler()
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

            try
            {
                var token = authHeader.Parameter;
                // 4. Check the database for a reuse of expired tokens.
                var expiredAccessToken = _expiredAccessTokenRepository.GetSingle(expiredToken => expiredToken.ExpiredTokenValue == token);

                // TODO: @Scott Will they always have just a one-time token here? Could be a good place to start adding some hook ins.
                if (expiredAccessToken != null && expiredAccessToken.CanReuse)
                {
                    expiredAccessToken.CanReuse = false;
                    _expiredAccessTokenRepository.Update(expiredAccessToken);
                }

                if (expiredAccessToken == null)
                {
                    // TODO: @Scott Please uncomment the inserting expired token when ready to deploy. It is annoying to test with.
                    // 5. Insert One time token so no one else uses it.
                    //_expiredAccessTokenRepository.Insert(new ExpiredAccessToken
                    //{
                    //    ExpiredTokenValue = token,
                    //    CanReuse = true
                    //});
                }

                // 6. Finally check if the token is validated and returns a principal.
                IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);

                // TODO: @Scott Add the additional authentication step for correct application.

                // 7. Authentication was successful, set the principal to notify other filters that
                // the request is authenticated.
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

            }
            catch (Exception e)
            {
                return SendError(tsc, e);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> SendError(TaskCompletionSource<HttpResponseMessage> tsc, Exception e)
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