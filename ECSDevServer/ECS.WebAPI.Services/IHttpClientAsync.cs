using System.Net.Http;
using System.Threading.Tasks;

namespace ECS.WebAPI.Services
{
    interface IHttpClientAsync
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsJsonAsync(string url, HttpContent content);
    }
}
