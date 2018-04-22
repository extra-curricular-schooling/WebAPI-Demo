using System.Web.Http.Controllers;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Transformers.Interfaces;

namespace ECS.WebAPI.Transformers
{
    public class SsoRegistrationTransformer : ISsoRegistrationTransformer
    {
        public SsoRegistrationRequestDTO Fetch(HttpRequestContext context)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var username = SsoJwtManager.Instance.GetClaimValue(context.Principal, "username");
            var password = SsoJwtManager.Instance.GetClaimValue(context.Principal, "password");
            var passwordSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(passwordSalt, password, true);
            var roleType = SsoJwtManager.Instance.GetClaimValue(context.Principal, "roleType");

            IFactory factory = new RoleFactory();
            string role = (string) factory.Create(roleType);
            

            return new SsoRegistrationRequestDTO
            {
                Username = username,
                Password = password,
                PasswordSalt =  passwordSalt,
                HashedPassword = hashedPassword,
                RoleType = role
            };
        }

        //public IHttpActionResult Send(HttpResponseMessage message)
        //{
        //    IHttpActionResult result = ResponseMessage(message);
        //    return new OkResult(message);
        //}
    }
}
