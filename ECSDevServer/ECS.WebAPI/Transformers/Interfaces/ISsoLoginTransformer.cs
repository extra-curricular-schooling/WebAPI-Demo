using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Services.Transformers.Interfaces
{
    public interface ISsoLoginTransformer
    {
        SsoLoginDTO Fetch (HttpRequestContext context);
    }
}
