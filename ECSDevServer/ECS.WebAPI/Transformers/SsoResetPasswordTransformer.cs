using System.Web.Http.Controllers;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers.Interfaces;

namespace ECS.WebAPI.Services.Transformers
{
    public class SsoResetPasswordTransformer : ISsoResetPasswordTransformer
    {
        public SsoResetPasswordRequestDTO Fetch(HttpRequestContext context)
        {
            var username = SsoJwtManager.Instance.GetClaimValue(context.Principal, "username");
            var newPassword = SsoJwtManager.Instance.GetClaimValue(context.Principal, "password");
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedNewPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, newPassword, true);
            return new SsoResetPasswordRequestDTO
            {
                Username = username,
                NewPassword = newPassword,
                PasswordSalt = passwordSalt,
                HashedNewPassword = hashedNewPassword
            };
        }
    }
}
