using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using ECS.DTO;
using ECS.DTO.Sso;

namespace ECS.WebAPI.Services.Transformers.Interfaces
{
    interface ISsoRegistrationTransformer
    {
        SsoRegistrationDTO Fetch(HttpRequestContext context);
    }
}
