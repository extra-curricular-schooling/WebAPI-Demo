using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
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
        [Route("GenerateCookie")]
        public HttpResponseMessage GenerateCookie()
        {
            var response = new HttpResponseMessage();
            string token = JwtManager.GenerateToken("luis");
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