using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Services.Transformers.Interfaces;

namespace ECS.WebAPI.Services.Transformers
{
    public class SsoLoginTransformer : ISsoLoginTransformer
    {
        public SsoLoginDTO Fetch(HttpRequestContext context)
        {
            var loginDto = new SsoLoginDTO
            {
                Username = SsoJwtManager.Instance.GetClaimValue(context.Principal, "username"),
                Password = SsoJwtManager.Instance.GetClaimValue(context.Principal, "password")
            };
            return loginDto;
        }
    }
}
