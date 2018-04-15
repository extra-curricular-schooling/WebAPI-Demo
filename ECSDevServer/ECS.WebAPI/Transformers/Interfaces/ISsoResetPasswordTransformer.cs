using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Services.Transformers.Interfaces
{
    interface ISsoResetPasswordTransformer
    {
        SsoResetPasswordRequestDTO Fetch(HttpRequestContext context);
    }
}
