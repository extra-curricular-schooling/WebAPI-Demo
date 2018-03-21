using ECS.Models;
using ECS.Repositories;
using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.Filters.AuthenticationFilters
{
    public class AuthenticationRequiredAttribute : AuthorizeAttribute, IDisposable
    {
        private JAccessTokenRepository _jwtRepository = new JAccessTokenRepository();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string accessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization.ToString() != null)
            {
                // get the access token
                accessTokenFromRequest = actionContext.Request.Headers.Authorization.ToString();

                string username = "";
                if (JwtManager.Instance.ValidateToken(accessTokenFromRequest, out username))
                {
                    string tempUsername = string.Copy(username);
                    JAccessToken accessToken = _jwtRepository.GetSingle(d => d.UserName == tempUsername, d => d.Account);
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