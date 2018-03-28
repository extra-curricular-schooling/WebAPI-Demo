using System.Net.Http;
using System.Web.Http.Controllers;
using ECS.DTO;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers.Interfaces;

namespace ECS.WebAPI.Services.Transformers
{
    public class SsoRegistrationTransformer : ISsoRegistrationTransformer
    {
        public SsoRegistrationDTO Fetch(HttpRequestContext context)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var username = SsoJwtManager.Instance.GetClaimValue(context.Principal, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(context.Principal, "password");
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, password, false);
            var roleType = SsoJwtManager.Instance.GetClaimValue(context.Principal, "roleType");
            return new SsoRegistrationDTO
            {
                Username = username,
                Password = password,
                PasswordSalt =  passwordSalt,
                HashedPassword = hashedPassword,
                RoleType = roleType
            };
        }
    }
}
