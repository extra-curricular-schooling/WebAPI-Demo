using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    /// <summary>
    /// Content Transformer for SSO Login
    /// </summary>
    public interface ISsoLoginTransformer
    {
        SsoLoginRequestDTO Fetch (HttpRequestContext context);
    }
}
