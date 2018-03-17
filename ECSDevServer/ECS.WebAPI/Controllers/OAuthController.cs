using DotNetOpenAuth.LinkedInOAuth2;
using ECS.Models;
using ECS.Repositories;
using ECS.WebAPI.Filters;
using ECS.WebAPI.Services.Security.AccessTokens.Jwt;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("OAuth")]
    public class OAuthController : ApiController
    {
        #region Constants and fields
        public object JsonWebToken { get; private set; }

        private LinkedInRepository _linkedInRepository = new LinkedInRepository();
        private AccountRepository _accountRepository = new AccountRepository();
        #endregion

        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string code, string state)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            string username = "";
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

                if(ProviderName == "linkedin")
                {
                    if(_linkedInRepository.Exists(d => d.UserName == username, d => d.Account))
                    {
                        LinkedIn currentToken = _linkedInRepository.GetSingle(d => d.UserName == username, d => d.Account);
                        currentToken.AccessToken = accessToken;
                        currentToken.TokenCreation = DateTime.Now.ToUniversalTime();
                        _linkedInRepository.Update(currentToken);
                    }
                    else
                    {
                        LinkedIn linkedinToken = new LinkedIn();
                        linkedinToken.AccessToken = accessToken;
                        linkedinToken.UserName = username;
                        linkedinToken.TokenCreation = DateTime.Now.ToUniversalTime();
                        _linkedInRepository.Insert(linkedinToken);
                    }
                }
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("RedirectToLinkedIn")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult RedirectToLinkedIn(string authtoken)
        {
            string username;
            
            if (JwtManager.Instance.ValidateToken(authtoken, out username))
            {
                string provider = "linkedin";
                var redirectUrl = "~/OAuth/ExternalLoginCallback?username=" + username;
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