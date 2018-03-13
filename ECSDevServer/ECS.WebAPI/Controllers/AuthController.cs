using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using ECS.Models;
using ECS.Repositories;
using ECS.WebAPI.Filters;
using ECS.WebAPI.Services;

namespace ECS.WebAPI.Controllers
{
    [RequireHttps]
    [RoutePrefix("Auth")]
    public class AuthController : ApiController
    {
        private JwtRepository _jwtRepository = new JwtRepository();

        [HttpGet]
        [AllowAnonymous]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        [Route("GenerateCookie")]
        public HttpResponseMessage GenerateCookie()
        {
            var response = new HttpResponseMessage();
            JWT token;

            // JWT token already exists
            if (_jwtRepository.Exists(d => d.UserName == "test1", d => d.Account))
            {
                token = _jwtRepository.GetSingle(d => d.UserName == "test1", d => d.Account);
                token.Value = JwtManager.Instance.GenerateToken("test1");
                _jwtRepository.Update(token);
            }
            // JWT does not exist for this user
            else
            {
                token = new JWT
                {
                    Value = JwtManager.Instance.GenerateToken("test1"),
                    UserName = "test1"
                };
                _jwtRepository.Insert(token);
            }
            
            //Build JSON response.
            var jsonMsg = new
            {
                auth_token = token.Value
            };

            var responseJson = new JavaScriptSerializer().Serialize(jsonMsg);
            response.Content = new StringContent(responseJson, Encoding.UTF8, "application/json");

            var cookie = new CookieHeaderValue("auth_token", token.Value)
            {
                Domain = ".localhost",
                HttpOnly = true,
                Path = "/; SameSite=Lax",
                Expires = DateTime.Now.AddMinutes(20)
            };
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
        }
    }
}