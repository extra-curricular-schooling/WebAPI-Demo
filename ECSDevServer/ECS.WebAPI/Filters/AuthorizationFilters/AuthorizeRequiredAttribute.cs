using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.Security.AccessTokens.Jwt;
using ECS.Constants.Security;

namespace ECS.WebAPI.Filters.AuthorizationFilters
{
    public class AuthorizeRequiredAttribute : AuthorizeAttribute, IDisposable
    {
        #region Constants and fields
        private readonly string[] _claimValues;
        #endregion

        public AuthorizeRequiredAttribute(params string[] claimValues)
        {
            _claimValues = claimValues;
        }
        
        /// <summary>
        /// Method to determine if the incoming request is authorized. 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns>Boolean</returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Get the claims principal.
            var principal = (ClaimsPrincipal) actionContext.RequestContext.Principal;
            if (principal == null)
            {
                // Get the Principal from the authorization header (Authentication was disabled).
                var accessTokenFromRequest = actionContext.Request.Headers.Authorization.Parameter;
                principal = JwtManager.Instance.GetPrincipal(accessTokenFromRequest);
                if (principal == null)
                {
                    return false;
                }
            }

            // Check PermissionName claims. Currently only works for single permissions.
            foreach (var value in _claimValues)
            {
                if (principal.HasClaim(ClaimTypes.Role, ClaimValues.Scholar))
                {
                    if (principal.HasClaim("PermissionName", value))
                    {
                        return true;
                    }
                }
                if (principal.HasClaim(ClaimTypes.Role, ClaimValues.Admin))
                {
                    if (principal.HasClaim("PermissionName", value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Calls base AuthorizeAttribute method to deal with unauthorized requests.
        /// </summary>
        /// <param name="actionContext"></param>
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