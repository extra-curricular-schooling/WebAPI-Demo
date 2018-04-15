using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Transformers.Interfaces
{
    public interface ISsoLoginTransformer
    {
        SsoLoginRequestDTO Fetch (HttpRequestContext context);

    }
}
