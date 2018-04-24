using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using ECS.Constants.Security;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Transformers.Interfaces;

namespace ECS.WebAPI.Transformers
{
    public class SsoLoginTransformer : ISsoLoginTransformer
    {
        public SsoLoginRequestDTO Fetch(HttpRequestContext context)
        {
            var loginDto = new SsoLoginRequestDTO
            {
                Username = SsoJwtManager.Instance.GetClaimValue(context.Principal, ClaimNames.Username),
                Password = SsoJwtManager.Instance.GetClaimValue(context.Principal, ClaimNames.Password),
                RoleType = SsoJwtManager.Instance.GetClaimValue(context.Principal, ClaimNames.RoleType)
            };
            return loginDto;
        }

        public IHttpActionResult Send(HttpResponseMessage response)
        {
            //switch (response.StatusCode)
            //{

            //}
            return new OkResult(new HttpRequestMessage());
        }
    }
}
