using System.Net.Http;

namespace ECS.WebAPI.Services
{
    interface IHttpClient
    {
        HttpResponseMessage Get(string url);
    }
}
