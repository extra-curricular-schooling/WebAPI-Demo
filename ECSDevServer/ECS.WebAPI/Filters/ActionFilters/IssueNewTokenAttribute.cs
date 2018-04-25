using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.Filters.ActionFilters
{
    public class IssueNewTokenAttribute : ActionFilterAttribute
    {
        private readonly IJAccessTokenRepository _jwtRepository;

        public IssueNewTokenAttribute()
        {
            _jwtRepository = new JAccessTokenRepository();
        }

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            string accessTokenFromRequest = "";
            {
                var authHeader = filterContext.Request.Headers.Authorization;
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
                            accessToken.DateTimeIssued = DateTime.UtcNow;
                            accessToken.Value = JwtManager.Instance.GenerateToken(username);
                            _jwtRepository.Update(accessToken);
                            filterContext.Response.Headers.Add("Authorization", accessToken.Value);
                        }
                        else
                        {
                            filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                            filterContext.Response.ReasonPhrase = "Invalid token.";
                        }
                    }
                    else
                    {
                        filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                        filterContext.Response.ReasonPhrase = "User does not have a current token.";
                    }
                }
                else
                {
                    if (JwtManager.Instance.ValidateExpiredToken(accessTokenFromRequest, out username))
                    {
                        if (_jwtRepository.Exists(d => d.UserName == username, d => d.Account))
                        {
                            JAccessToken accessToken = _jwtRepository.GetSingle(d => d.UserName == username, d => d.Account);
                            if (accessToken != null)
                            {
                                string accessTokenStored = accessToken.Value;
                                if (accessTokenFromRequest == accessTokenStored && accessToken.DateTimeIssued.AddDays(1).CompareTo(DateTime.Now.ToUniversalTime()) > 0)
                                {
                                    accessToken.DateTimeIssued = DateTime.UtcNow;
                                    accessToken.Value = JwtManager.Instance.GenerateToken(username);
                                    _jwtRepository.Update(accessToken);
                                    filterContext.Response.Headers.Add("Authorization", accessToken.Value);
                                }
                                else
                                {
                                    filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                                    filterContext.Response.ReasonPhrase = "Invalid token.";
                                }
                            }
                            else
                            {
                                filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                                filterContext.Response.ReasonPhrase = "User does not have a current token.";
                            }
                        }
                        else
                        {
                            filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                            filterContext.Response.ReasonPhrase = "User does not have a current token.";
                        }
                    }
                    else
                    {
                        filterContext.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                        filterContext.Response.ReasonPhrase = "Invalid token.";
                    }
                }
            }
        }
    }
}