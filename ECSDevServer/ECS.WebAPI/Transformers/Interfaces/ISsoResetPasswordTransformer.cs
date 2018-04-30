using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    /// <summary>
    /// Content Transformer for SSO Reset Password
    /// </summary>
    public interface ISsoResetPasswordTransformer
    {
        SsoResetPasswordRequestDTO Fetch(HttpRequestContext context);
    }
}
