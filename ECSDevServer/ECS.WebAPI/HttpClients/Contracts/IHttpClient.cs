using System.Net.Http;

namespace ECS.WebAPI.HttpClients.Contracts
{
    interface IHttpClient
    {
        HttpResponseMessage Get(string url);
    }
}
