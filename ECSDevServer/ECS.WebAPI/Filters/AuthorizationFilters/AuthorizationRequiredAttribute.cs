using ECS.WebAPI.Services;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ECS.WebAPI.Filters.AuthenticationFilters
{
    public class AuthorizationRequiredAttribute : AuthorizeAttribute, IDisposable
    {
        #region Constants and fields
        private string _claim;
        private string[] _claims;
        private bool _isSingleClaim;
        #endregion

        public AuthorizationRequiredAttribute(string claim)
        {
            _claim = claim;
            _isSingleClaim = true;
        }

        public AuthorizationRequiredAttribute(string[] claims)
        {
            _claims = claims;
            _isSingleClaim = false;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string accessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization.ToString() != null)
            {
                // get the access token
                accessTokenFromRequest = actionContext.Request.Headers.Authorization.ToString();

                ClaimsPrincipal principal = JwtManager.Instance.GetPrincipal(accessTokenFromRequest);
                if(principal != null)
                {
                    if(_isSingleClaim)
                    {
                        if(principal.HasClaim("AccountType", _claim))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        foreach (string claim in _claims)
                        {
                            if (principal.HasClaim("AccountType", claim))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
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