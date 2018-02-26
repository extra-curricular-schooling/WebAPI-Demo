using ECS.WebAPI.Filters;
using ECS.WebAPI.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    public class OAuthController : ApiController
    {
        #region Constants and fields
        private readonly string _clientUri = "http://localhost:8080/";

        public object JsonWebToken { get; private set; }
        #endregion

        [AllowAnonymous]
        public IHttpActionResult ExternalLoginCallback(string returnUrl)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (ProviderName == null || ProviderName == "")
            {
                NameValueCollection nvs = Request.QueryString;
                if (nvs.Count > 0)
                {
                    if (nvs["state"] != null)
                    {
                        NameValueCollection provideritem = HttpUtility.ParseQueryString(nvs["state"]);
                        if (provideritem["__provider__"] != null)
                        {
                            ProviderName = provideritem["__provider__"];
                        }
                    }
                }
            }

            LinkedInOAuth2Client.RewriteRequest();

            var redirectUrl = Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl });
            var authResult = OpenAuth.VerifyAuthentication(redirectUrl);

            string providerDisplayName = OpenAuth.GetProviderDisplayName(ProviderName);

            if (!authResult.IsSuccessful)
            {
                return Redirect(Url.Action("Index", "Home"));
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

                return RedirectToAction("RedirectToClient");
            }
        }

        internal class ExternalLoginResult : IHttpActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            // needs to be implemented for IHttpActionResult
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }

            public override void ExecuteResult(ControllerContext context)
            {
                // Request authentication from the provider specified by 
                // redirecting the user to the service's login page.
                OpenAuth.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        // GET: Auth
        [AllowAnonymous]
        public IHttpActionResult RedirectToClient()
        {
            return Redirect(_clientUri);
        }

        [AllowAnonymous]
        public IHttpActionResult RedirectToLinkedIn(string authtoken)
        {
            string username;
            if (JwtManager.ValidateToken(authtoken, out username))
            {
                string provider = "linkedin";
                string returnUrl = "https://localhost:44313/OAuth/ExternalLoginCallback";
                return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            }
            else
            {
                Response.StatusCode = 401;
                return new EmptyResult();
            }
            //if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("auth_token"))
            //{
            //    var cookie = Request.Cookies.Get("auth_token");
            //    var token = cookie.Value;

            //    string username;
            //    if (ValidateToken(token, out username))
            //    {
            //        string provider = "linkedin";
            //        string returnUrl = "";
            //        return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            //    }
            //    else
            //    {
            //        return new EmptyResult();
            //    }
            //}
        }
    }
}