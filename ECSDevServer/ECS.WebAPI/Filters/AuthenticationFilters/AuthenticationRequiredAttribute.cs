using ECS.Models;
using ECS.Repositories;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.Security.AccessTokens.Jwt;
using System.Security.Claims;

namespace ECS.WebAPI.Filters.AuthenticationFilters
{
    public class AuthenticationRequiredAttribute : AuthorizeAttribute, IDisposable
    {
        private readonly IJAccessTokenRepository _jwtRepository;

        public AuthenticationRequiredAttribute()
        {
            _jwtRepository = new JAccessTokenRepository();
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string accessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization.ToString() != null)
            {
                var authHeader = actionContext.Request.Headers.Authorization;
                if (authHeader != null)
                {
                    var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader.ToString());

                    // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                    if (authHeaderVal.Scheme.Equals("bearer",
                            StringComparison.OrdinalIgnoreCase) &&
                        authHeaderVal.Parameter != null)
                    {
                        accessTokenFromRequest = authHeaderVal.Parameter;
                    }
                }
                // get the access token
                // accessTokenFromRequest = actionContext.Request.Headers.Authorization.ToString();

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
                // Token is either not valid or expired
                else
                {
                    if(JwtManager.Instance.ValidateExpiredToken(accessTokenFromRequest, out username))
                    {
                        if (_jwtRepository.Exists(d => d.UserName == username, d => d.Account))
                        {
                            JAccessToken accessToken = _jwtRepository.GetSingle(d => d.UserName == username, d => d.Account);
                            if (accessToken != null)
                            {
                                string accessTokenStored = accessToken.Value;
                                if (accessTokenFromRequest == accessTokenStored && accessToken.DateTimeIssued.AddDays(1).CompareTo(DateTime.Now.ToUniversalTime()) > 0)
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