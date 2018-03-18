using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;

namespace ECS.WebAPI.Services.Security.AccessTokens.Jwt
{
    public class SsoJwtHelper : IJwtHelper
    {
        // Instance for Singleton Pattern
        private static SsoJwtHelper instance;

        private SsoJwtHelper()
        {
        }

        public static SsoJwtHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SsoJwtHelper();
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

        public string GetUsernameFromToken(String token)
        {
            var principal = SsoJwtManager.Instance.GetPrincipal(token);
            if (null != principal)
            {
                foreach (Claim claim in principal.Claims)
                {
                    if (claim.Type.Equals("username"))
                    {
                        return claim.Value;
                    }
                }
            }
            return "";
        }
    }
}
