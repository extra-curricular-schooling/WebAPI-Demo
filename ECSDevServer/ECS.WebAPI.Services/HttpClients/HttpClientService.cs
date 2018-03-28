using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ECS.WebAPI.Services.HttpClients.Interfaces;

namespace ECS.WebAPI.Services.HttpClients
{
    // This needs some sort of locking mechanism to ensure thread safety!!!

    // Use System.net.http.httpclient to receive and request
    public class HttpClientService: IHttpClient, IHttpClientAsync, IDisposable
    {
        public void Dispose() { }

        private readonly HttpClient _httpClient = new HttpClient();

        // Using Singleton Pattern improves the performance because only one connection is needed
        // but we can still implement interfaces.
        private static HttpClientService _ssoInstance;
        private static HttpClientService _badPasswordWebServiceInstance;

        private HttpClientService()
        {
            // Test case: Headers not being cleared??
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            // Test case: Does it only Accept JSON??
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClientService SsoInstance
        {
            get
            {
                if (_ssoInstance == null)
                {
                    _ssoInstance = new HttpClientService();
                }
                return _ssoInstance;
            }
        }

        public static HttpClientService BadPasswordWebServiceInstance
        {
            get
            {
                if (_badPasswordWebServiceInstance == null)
                {
                    _badPasswordWebServiceInstance = new HttpClientService();
                }
                return _badPasswordWebServiceInstance;
            }
        }

        public HttpResponseMessage Get(string url)
        {
            try
            {
                var responseTask = _httpClient.GetAsync(url);
                responseTask.Wait();
                return responseTask.Result;
            }
            catch(HttpRequestException ex)
            {
                // Fix up the error handling
                Debug.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return null;
            }
            
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync(string url, string jsonString)
        {
            try
            {
                // Format obj into HttpContent
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Required additional package: System.Net.Http.Formatting.Extension
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, jsonString);
                response.EnsureSuccessStatusCode();

                // return Result of the created resource.
                return response;
            }
            catch (HttpRequestException ex)
            {
                // Fix up the error handling
                Debug.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return null;
            }

        }

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T obj)
        {
            try
            {
                // Required additional package: System.Net.Http.Formatting.Extension
                // Default serialization into a JSON object for PostAsJsonAsync
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, obj);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response;
            }
            catch (HttpRequestException ex)
            {
                // Fix up the error handling
                Debug.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return null;
            }

        }

        public async Task<T> GetTaskObjectAsync<T>(string path)
        {
            try
            {
                T obj = default(T);
                HttpResponseMessage response = await _httpClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<T>();
                }
                return obj;
            }
            catch (HttpRequestException ex)
            {
                // Fix up the error handling
                Debug.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return default(T);
            }
        }
    }
}