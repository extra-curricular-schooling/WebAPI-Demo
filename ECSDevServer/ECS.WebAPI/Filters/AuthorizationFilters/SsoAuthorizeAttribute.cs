using ECS.Models;
using ECS.Repositories;
using ECS.WebAPI.Services;
using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ECS.WebAPI.Filters.AuthorizationFilters
{
    public class SsoAuthorizeAttribute : AuthorizeAttribute, IDisposable
    {
        private JwtRepository _jwtRepository = new JwtRepository();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string accessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization != null)
            {
                // get the access token from the appropriate header...



                accessTokenFromRequest = actionContext.Request.Headers.Authorization.Parameter;

                if (JwtManager.Instance.ValidateToken(accessTokenFromRequest, out string username))
                {
                    JWT accessToken = _jwtRepository.GetSingle(d => d.UserName == username, d => d.Account);
                    if (accessToken != null)
                    {
                        string accessTokenStored = accessToken.Value;
                        if (accessTokenFromRequest == accessTokenStored)
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