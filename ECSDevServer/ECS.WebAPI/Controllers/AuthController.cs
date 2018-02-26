using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ECS.WebAPI.Services;

namespace ECS.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GenerateCookie()
        {
            string token = JwtManager.GenerateToken("luis");
            HttpCookie cookie = new HttpCookie("auth_token");
            cookie.Value = token;
            cookie.Domain = ".localhost";
            cookie.HttpOnly = true;
            cookie.Path = "/; SameSite=Lax";
            cookie.Expires = DateTime.Now.AddMinutes(20);
            Response.AppendCookie(cookie);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}