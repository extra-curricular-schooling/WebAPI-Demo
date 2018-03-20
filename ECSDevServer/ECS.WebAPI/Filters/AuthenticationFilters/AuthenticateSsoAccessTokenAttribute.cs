using ECS.Repositories;
using ECS.WebAPI.Services.Security.AccessTokens.Jwt;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using ECS.Models;

namespace ECS.WebAPI.Filters.AuthenticationFilters
{
    public class AuthenticateSsoAccessTokenAttribute : Attribute, IAuthenticationFilter, IDisposable
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;

        public AuthenticateSsoAccessTokenAttribute()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
        }

        // Not allowed to authenticate more than once.
        // Change to "true" if you allow multiple AuthenticateSsoAccessToken attribute filters.
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 0. Look to see if you allow anonymous access???
            var actionDescriptor = context.ActionContext.ActionDescriptor;
            var isAnonymousAllowed = actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any() ||
                actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any();
            if (isAnonymousAllowed)
            {
                return;
            }

            // 1. Look for credentials in the request.
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                return;
            }

            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (authorization.Scheme != "Bearer")
            {
                return;
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are malformed, set the error result.
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Malformed credentials", request);
                return;
            }

            // 6. Gather necessary information to check the token.
            var token = authorization.Parameter;

            // 7. Check for replay tokens.
            if (_expiredAccessTokenRepository.GetById(token) != null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                return;
            }

            // TODO: @Scott The expired access token insert is causing a EntityValidationError. Fix
            // Insert One time token
            //_expiredAccessTokenRepository.Insert(new ExpiredAccessToken(token));

            // 8. Authentication was successful, set the principal to notify other filters that
            // the request is authenticated.
            IPrincipal principal = SsoJwtManager.Instance.GetPrincipal(token);
            await Task.Run(() =>
            {
                Thread.CurrentPrincipal = principal;
                context.Principal = principal;
            }, cancellationToken);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Bearer");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }

        // FIGURE OUT HOW TO IMPLEMENT DISPOSE PROPERLY!!!!!!!!!!!!!!!!!!!
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        private string ReasonPhrase { get; }

        private HttpRequestMessage Request { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };
            return response;
        }
    }

    // This is making a wrapper that will surround the response object if there
    // is an authentication failure.
    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            Challenge = challenge;
            InnerResult = innerResult;
        }

        private AuthenticationHeaderValue Challenge { get; }

        private IHttpActionResult InnerResult { get; }

        // This portion gets called after the controller has finished. (The reverse invocation of the pipeline)
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await InnerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

            // Only add one challenge per authentication scheme.
            if (response.Headers.WwwAuthenticate.All(h => h.Scheme != Challenge.Scheme))
            {
                response.Headers.WwwAuthenticate.Add(Challenge);
            }

            return response;
        }
    }
}