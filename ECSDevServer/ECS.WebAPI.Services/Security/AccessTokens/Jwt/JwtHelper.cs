using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECS.WebAPI.Services.Security.AccessTokens.Jwt
{
    public class JwtHelper : IJwtHelper
    {
        // Instance for Singleton Pattern
        private static JwtHelper instance;

        private JwtHelper()
        {
        }

        public static JwtHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JwtHelper();
                }
                return instance;
            }
        }

        // Should be deleted... Unless we need multiple JWTs from different headers.
        public List<string> GetJwtsFromHttpHeaders(HttpRequestMessage request)
        {
            var jwtList = new List<string>();
            if (request.Headers.Authorization != null)
            {
                jwtList.Add(request.Headers.Authorization.Parameter);
            }
            return jwtList;
        }

        public string GetJwtFromAuthorizationHeader(HttpRequestMessage request)
        {
            return request.Headers.Authorization.Parameter;
        }

        // Throws null reference if Name is null
        public string GetUsernameFromToken(String token)
        {
            var principal = JwtManager.Instance.GetPrincipal(token);
            return principal.Identity.Name;
        }
    }
}
