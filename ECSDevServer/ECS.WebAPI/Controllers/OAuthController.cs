using DotNetOpenAuth.LinkedInOAuth2;
using ECS.WebAPI.Filters;
using ECS.WebAPI.Services;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("OAuth")]
    public class OAuthController : ApiController
    {
        #region Constants and fields
        private readonly string _clientUri = "http://localhost:8080/#/";

        public object JsonWebToken { get; private set; }
        #endregion

        [AllowAnonymous]
        [HttpGet]
        [Route("ExternalLoginCallback")]
        public IHttpActionResult ExternalLoginCallback(string code, string state)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (ProviderName == null || ProviderName == "")
            {
                var nvs = Request.GetQueryNameValuePairs();
                string stateParam = nvs.LastOrDefault(x => x.Key == "state").Value;
                if (state != null)
                {
                    NameValueCollection provideritem = HttpUtility.ParseQueryString(stateParam);
                    if (provideritem["__provider__"] != null)
                    {
                        ProviderName = provideritem["__provider__"];
                    }
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

                return RedirectToClient();
            }
        }

        // GET: Auth
        [AllowAnonymous]
        [Route("RedirectToClient")]
        public IHttpActionResult RedirectToClient()
        {
            return Redirect(_clientUri);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("RedirectToLinkedIn")]
        public IHttpActionResult RedirectToLinkedIn(string authtoken)
        {
            string username;
            if (JwtManager.ValidateToken(authtoken, out username))
            {
                string provider = "linkedin";
                //string returnUrl = "https://localhost:44311/OAuth/ExternalLoginCallback";
                var redirectUrl = "~/OAuth/ExternalLoginCallback";
                //if (!String.IsNullOrEmpty(returnUrl))
                //{
                //    redirectUrl += "?ReturnUrl=" + HttpUtility.UrlEncode(returnUrl);
                //}
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