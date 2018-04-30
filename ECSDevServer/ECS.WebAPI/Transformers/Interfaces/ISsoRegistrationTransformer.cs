using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    /// <summary>
    /// Content Transformer for SSO Registration
    /// </summary>
    public interface ISsoRegistrationTransformer
    {
        SsoRegistrationRequestDTO Fetch(HttpRequestContext context);
    }
}
