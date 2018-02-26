using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using ECS.WebAPI.Filters;
using ECS.WebAPI.Services;

namespace ECS.WebAPI.Controllers
{
    [RequireHttps]
    [RoutePrefix("Auth")]
    public class AuthController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        [Route("GenerateCookie")]
        public HttpResponseMessage GenerateCookie()
        {
            var response = new HttpResponseMessage();
            string token = JwtManager.GenerateToken("luis");

            //Build JSON response.
            var jsonMsg = new
            {
                auth_token = token
            };

            var responseJson = new JavaScriptSerializer().Serialize(jsonMsg);
            response.Content = new StringContent(responseJson, Encoding.UTF8, "application/json");

            var cookie = new CookieHeaderValue("auth_token", token);
            cookie.Domain = ".localhost";
            cookie.HttpOnly = true;
            cookie.Path = "/; SameSite=Lax";
            cookie.Expires = DateTime.Now.AddMinutes(20);
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
        }
    }
}