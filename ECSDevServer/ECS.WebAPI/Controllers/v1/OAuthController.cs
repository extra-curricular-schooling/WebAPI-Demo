using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DotNetOpenAuth.LinkedInOAuth2;
using ECS.Constants.Network;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Filters.AuthorizationFilters;
using Microsoft.AspNet.Membership.OpenAuth;

namespace ECS.WebAPI.Controllers.v1
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("v1/OAuth")]
    public class OAuthController : ApiController
    {
        #region Constants and fields
        private string _externalCallBack = "~/v1/OAuth/ExternalLoginCallback";
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        private readonly ILinkedInAccessTokenRepository _linkedInAccessTokenRepository = new LinkedInAccessTokenRepository();
        #endregion

        /// <summary>
        /// This callback is triggered when the user cancels the OAuth2 process
        /// </summary>
        /// <param name="error">Error code provided by LinkedIn</param>
        /// <param name="error_description">Description of error provided by LinkedIn</param>
        /// <param name="state">Returns the state we provided LinkedIn when we redirected the user to their website</param>
        /// <returns>
        /// Redirects to the provided return uri or the default home page of our web app
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string error, string error_description, string state)
        {
            var nvs = Request.GetQueryNameValuePairs();
            string stateParam = nvs.LastOrDefault(d => d.Key == "state").Value;
            // Default return uri
            string returnURI = "https://localhost:8080/Home";
            // If the query string for state is not empty
            if (state != null)
            {
                // We need some variables from our state parameter.
                NameValueCollection provideritem = HttpUtility.ParseQueryString(stateParam);
                // Check for a return uri query string parameter
                if (provideritem["returnURI"] != null)
                {
                    returnURI = provideritem["returnURI"];
                }
            }

            // Try to redirect to the provided return uri
            try
            {
                return Redirect(returnURI);
            }
            catch (Exception)
            {
                return Redirect("https://localhost:8080/Home");
            }
        }

        /// <summary>
        /// Callback LinkedIn sends the user to after successfully logging in
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state">Returns the state we provided LinkedIn when we redirected the user to their website</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string code, string state)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            string username = "";
            string returnURI = "";
            // For future user when we integrate with other oauth2 applications
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
                        if(!_accountRepository.Exists(d => d.UserName == username))
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
            else
            {
                var nvs = Request.GetQueryNameValuePairs();
                string stateParam = nvs.LastOrDefault(d => d.Key == "state").Value;
                if (state != null)
                {
                    // We need some variables from our state parameter.
                    NameValueCollection provideritem = HttpUtility.ParseQueryString(stateParam);

                    if (provideritem["username"] != null)
                    {
                        username = provideritem["username"];
                        // Check to make sure username exists in database.
                        if (!_accountRepository.Exists(d => d.UserName == username))
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

            // Rewrite the request to include the requested headers and info for exchanging
            // the authorization code for a LinkedIn access token
            LinkedInOAuth2Client.RewriteRequest();
            
            // Now that the request has been rewritten, make the call and include the same callback uri provided earlier
            var authResult = OpenAuth.VerifyAuthentication(_externalCallBack);

            // For future user when we integrate with other oauth2 applications
            string providerDisplayName = OpenAuth.GetProviderDisplayName(ProviderName);

            //If the verification process failed
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
                    // If the given user already has a LinkedIn access token
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
                    // Try the given redirectUri
                    try
                    {
                        return Redirect(returnURI + "?linkedin=success");
                    }
                    // If it fails, go with the default
                    catch (Exception)
                    {
                        return Redirect("http://localhost:8080/Home?linkedin=success");
                    }
                    
                }

                return Redirect("http://localhost:8080/Home?linkedin=success");
            }
        }

        /// <summary>
        /// Redirects the user to LinkedIn's OAuth2 portal
        /// </summary>
        /// <param name="authtoken">
        /// This call cannot be an AJAX call due to the CORS issues with LinkedIn, the Jwt
        /// token of the user must be passed through this query string
        /// </param>
        /// <param name="returnURI">
        /// Where to redirect the user after either finishing the process or aborting it
        /// halfway through it
        /// </param>
        /// <returns>
        /// - Success: (Valid Jwt)
        ///     302 status code
        ///         Redirects the client to the start of LinkedIn's OAuth2 process
        /// - Failure:
        ///     401 status code
        ///         Invalid or missing Jwt
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("RedirectToLinkedIn")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult RedirectToLinkedIn(string authtoken, string returnURI)
        {
            string username;
            // Username is passed by reference, thus it is assigned inside validateToken
            // Validate Jwt to ensure maximum 
            if (JwtManager.Instance.ValidateToken(authtoken, out username))
            {
                string provider = "linkedin";
                var redirectUrl = _externalCallBack + "?username=" + username + "&returnURI=" + HttpUtility.UrlEncode(returnURI);
                OpenAuth.RequestAuthentication(provider, redirectUrl);
                // Here to satisfy compiler, have no idea how you would trigger this.
                return Ok();
            }
            // Invalid or missing Jwt
            else
            {
                return Unauthorized();
            }
        }
    }
}