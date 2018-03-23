 using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ECS.WebAPI.Filters.AuthorizationFilters
{
    public class AuthorizeSsoAccessTokenAttribute : AuthorizeAttribute
    {
        #region Constants and fields
        //{"Scott", {"}
        // Authorize({{"scott", {"DUH", "Hello"}}})
        // Authorize("hello")
        private List<Dictionary<string, List<string>>> _claims;
        
        #endregion

        public AuthorizeSsoAccessTokenAttribute(List<Dictionary<string, List<string>>> claims)
        {
            _claims = claims;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Authentication has already occured, so we don't need to validate the token again to get the principal
            var requestPrincipal = (ClaimsPrincipal) actionContext.Request.GetRequestContext().Principal;


            if (requestPrincipal != null)
            {
                var claimsPrincipal = (ClaimsPrincipal) requestPrincipal;
                // TODO: @Scott Please make sure this Linq statement is correct.
               
                return _claims.All(claim => claimsPrincipal.HasClaim(claim.ToString(), claim.ToString()));
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            Debug.WriteLine("Running HandleUnauthorizedRequest in CustomAuthorizationFilterAttribute as principal is not authorized.");
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}