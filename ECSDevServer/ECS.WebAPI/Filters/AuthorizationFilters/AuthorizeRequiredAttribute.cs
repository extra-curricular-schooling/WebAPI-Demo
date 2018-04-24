using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.Filters.AuthorizationFilters
{
    public class AuthorizeRequiredAttribute : AuthorizeAttribute, IDisposable
    {
        #region Constants and fields
        private string _claim;
        private string[] _claims;
        private bool _isSingleClaim;
        #endregion
        // Single Claim probably won't need
        public AuthorizeRequiredAttribute(string claim)
        {
            _claim = claim;
            _isSingleClaim = true;
        }

        public AuthorizeRequiredAttribute(string[] claims)
        {
            _claims = claims;
            _isSingleClaim = false;
        }
        public AuthorizeRequiredAttribute()
        {

        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string accessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization.ToString() != null)
            {
                // get the access token
                accessTokenFromRequest = actionContext.Request.Headers.Authorization.ToString();

                ClaimsPrincipal principal = JwtManager.Instance.GetPrincipal(accessTokenFromRequest);
                if (principal != null)
                {
                    foreach (string claim in _claims)
                    {
                        if (principal.HasClaim(ClaimTypes.Role, "Scholar"))
                        {
                            if (principal.HasClaim("PermissionName", claim))
                            {
                                return true;
                            }
                        }
                        else if (principal.HasClaim(ClaimTypes.Role, "Admin"))
                        {
                            if (principal.HasClaim("PermissionName", claim))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            Debug.WriteLine("Running HandleUnauthorizedRequest in CustomAuthorizationFilterAttribute as principal is not authorized.");
            base.HandleUnauthorizedRequest(actionContext);
        }

        public void Dispose()
        {
        }
    }
}