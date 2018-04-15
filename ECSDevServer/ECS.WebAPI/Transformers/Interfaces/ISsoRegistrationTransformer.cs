using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    interface ISsoRegistrationTransformer
    {
        SsoRegistrationRequestDTO Fetch(HttpRequestContext context);
    }
}
