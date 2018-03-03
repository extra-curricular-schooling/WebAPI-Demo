using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
/// <remarks>Author: Scott Roberts</remarks>
namespace ECS.WebAPI.Services
{
    // This needs some sort of locking mechanism to ensure thread safety!!!

    // Use System.net.http.httpclient to receive and request
    public class HttpClientService: IHttpClient, IHttpClientAsync, IDisposable
    {
        public void Dispose() { }

        private HttpClient httpClient = new HttpClient();

        // Using Singleton Pattern improves the performance because only one connection is needed
        // but we can still implement interfaces.
        private static HttpClientService ssoInstance;
        private static HttpClientService badPasswordWebServiceInstance;

        private HttpClientService()
        {
            // Test case: Headers not being cleared??
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Test case: Does it only Accept JSON??
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClientService SsoInstance
        {
            get
            {
                if (ssoInstance == null)
                {
                    ssoInstance = new HttpClientService();
                }
                return ssoInstance;
            }
        }

        public static HttpClientService BadPasswordWebServiceInstance
        {
            get
            {
                if (badPasswordWebServiceInstance == null)
                {
                    badPasswordWebServiceInstance = new HttpClientService();
                }
                return badPasswordWebServiceInstance;
            }
        }

        public HttpResponseMessage Get(string url)
        {
            try
            {
                var responseTask = httpClient.GetAsync(url);
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
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, jsonString);
                response.EnsureSuccessStatusCode();
                var result = response.Content;

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
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, obj);
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
                HttpResponseMessage response = await httpClient.GetAsync(path);
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