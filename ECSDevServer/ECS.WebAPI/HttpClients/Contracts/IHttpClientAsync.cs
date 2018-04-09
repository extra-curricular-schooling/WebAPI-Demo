using System.Net.Http;
using System.Threading.Tasks;

namespace ECS.WebAPI.HttpClients.Contracts
{
    interface IHttpClientAsync
    {
        // https://msdn.microsoft.com/en-us/library/system.net.http.httpclient.postasync(v=vs.110).aspx
        Task<HttpResponseMessage> PostAsJsonAsync(string url, string jsonString);
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T obj);
        Task<T> GetTaskObjectAsync<T>(string path);
    }
}
