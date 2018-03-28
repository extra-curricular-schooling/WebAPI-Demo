using System.Net.Http;

namespace ECS.WebAPI.Services.HttpClients.Interfaces
{
    interface IHttpClient
    {
        HttpResponseMessage Get(string url);
    }
}
