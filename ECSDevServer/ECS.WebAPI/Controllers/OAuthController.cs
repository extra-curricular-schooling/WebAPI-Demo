using DotNetOpenAuth.LinkedInOAuth2;
using ECS.Models;
using ECS.Repositories;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("OAuth")]
    public class OAuthController : ApiController
    {
        #region Constants and fields
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        private readonly ILinkedInAccessTokenRepository _linkedInAccessTokenRepository = new LinkedInAccessTokenRepository();
        #endregion

        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string error, string error_description, string state)
        {
            var nvs = Request.GetQueryNameValuePairs();
            string stateParam = nvs.LastOrDefault(d => d.Key == "state").Value;
            string returnURI = "https://localhost:8080/#/Home";
            if (state != null)
            {
                // We need some variables from our state parameter.
                    NameValueCollection provideritem = HttpUtility.ParseQueryString(stateParam);
                    if (provideritem["returnURI"] != null)
                    {
                    returnURI = provideritem["returnURI"];
                }
            }

            try
            {
                return Redirect(returnURI);
            }
            catch (Exception)
            {
                return BadRequest("Invalid return url.");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string code, string state)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            string username = "";
            string returnURI = "";
            if (ProviderName == null || ProviderName == "")
            {
                var nvs = Request.GetQueryNameValuePairs();
                string stateParam = nvs.LastOrDefault(d => d.Key == "state").Value;
                if (state != null)
                {
                    // We need some variables from our state parameter.
                    NameValueCollection provideritem = HttpUtility.ParseQueryString(stateParam);
                    if (provideritem["__provider__"] != null)
                    {
                        ProviderName = provideritem["__provider__"];
                    }

                    if (provideritem["username"] != null)
                    {
                        username = provideritem["username"];
                        // Check to make sure username exists in database.
                        if(!_accountRepository.Exists(d => d.UserName == username, d => d.User))
                        {
                            return Unauthorized();
                        }
                    }
                    // No username was provided.
                    else
                    {
                        return Unauthorized();
                    }

                    if (provideritem["returnURI"] != null)
                    {
                        returnURI = provideritem["returnURI"];
                    }
                }
                else
                {
                    return BadRequest();
                }
            }

            LinkedInOAuth2Client.RewriteRequest();

            var returnUrl = "~/OAuth/ExternalLoginCallback";
            var authResult = OpenAuth.VerifyAuthentication(returnUrl);

            string providerDisplayName = OpenAuth.GetProviderDisplayName(ProviderName);

            if (!authResult.IsSuccessful)
            {
                return Unauthorized();
            }
            else
            {
                //Get provider user details
                string providerUserId = authResult.ProviderUserId;
                string providerUserName = authResult.UserName;
                string firstName = null;
                string lastName = null;
                string accessToken = null;
                string email = null;

                if (email == null && authResult.ExtraData.ContainsKey("email-address"))
                {
                    email = authResult.ExtraData["email-address"];
                }
                if (firstName == null && authResult.ExtraData.ContainsKey("first-name"))
                {
                    firstName = authResult.ExtraData["first-name"];
                }
                if (lastName == null && authResult.ExtraData.ContainsKey("last-name"))
                {
                    lastName = authResult.ExtraData["last-name"];
                }
                if (accessToken == null && authResult.ExtraData.ContainsKey("accesstoken"))
                {
                    accessToken = authResult.ExtraData["accesstoken"];
                }
                var userInfo = new List<object>();
                userInfo.Add(new
                {
                    ProviderDisplayName = providerDisplayName,
                    ProviderUserId = providerUserId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    AccessToken = accessToken
                });

                try
                {
                    if (_linkedInAccessTokenRepository.Exists(d => d.UserName == username, d => d.Account))
                    {
                        LinkedInAccessToken token = _linkedInAccessTokenRepository.GetSingle(d => d.UserName == username, d => d.Account);
                        token.Expired = false;
                        token.TokenCreation = DateTime.UtcNow;
                        token.Value = accessToken;
                        _linkedInAccessTokenRepository.Update(token);
                    }
                    else
                    {
                        LinkedInAccessToken token = new LinkedInAccessToken()
                        {
                            UserName = username,
                            TokenCreation = DateTime.UtcNow,
                            Value = accessToken
                        };
                        _linkedInAccessTokenRepository.Insert(token);
                    }
                } catch (Exception)
                {
                    return InternalServerError();
                }

                if(returnURI != "null")
                {
                    try
                    {
                        return Redirect(returnURI);
                    } catch (Exception)
                    {
                        return Ok("Return url was invalid though.");
                    }
                    
                }

                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("RedirectToLinkedIn")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult RedirectToLinkedIn(string authtoken, string returnURI)
        {
            string username;
            
            if (JwtManager.Instance.ValidateToken(authtoken, out username))
            {
                string provider = "linkedin";
                var redirectUrl = "~/OAuth/ExternalLoginCallback?username=" + username + "&returnURI=" + HttpUtility.UrlEncode(returnURI);
                OpenAuth.RequestAuthentication(provider, redirectUrl);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}