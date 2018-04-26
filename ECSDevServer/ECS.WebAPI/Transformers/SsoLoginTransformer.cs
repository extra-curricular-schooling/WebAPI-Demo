using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Security;
using ECS.DTO;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Transformers.Interfaces;

namespace ECS.WebAPI.Transformers
{
    public class SsoLoginTransformer : ISsoLoginTransformer
    {
        private PartialAccountLogic _partialAccountLogic = new PartialAccountLogic();

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

        public SsoLoginRequestDTO Fetch(AccountCredentialDTO credentials)
        {
            var loginDto = new SsoLoginRequestDTO
            {
                Username = credentials.Username,
                Password = credentials.Password,
                RoleType = _partialAccountLogic.GetPartialAccount(credentials.Username).AccountType
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
