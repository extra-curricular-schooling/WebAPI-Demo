using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    interface ISsoResetPasswordTransformer
    {
        SsoResetPasswordRequestDTO Fetch(HttpRequestContext context);
    }
}
