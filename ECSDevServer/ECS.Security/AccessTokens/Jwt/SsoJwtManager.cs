using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using ECS.DTO;
using ECS.DTO.Sso;
using ECS.Repositories;
using ECS.Repositories.Implementations;
using Microsoft.IdentityModel.Tokens;

namespace ECS.Security.AccessTokens.Jwt
{
    public class SsoJwtManager : IJwtManager
    {
        #region Constants and fields
        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        // Single repository to query users associated with tokens.
        private readonly IAccountRepository _accountRepository;

        // Instance for Singleton Pattern
        private static SsoJwtManager _instance;
        #endregion

        private SsoJwtManager()
        {
            _accountRepository = new AccountRepository();
        }

        public static SsoJwtManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SsoJwtManager();
                }
                return _instance;
            }
        }

        private ClaimsIdentity CreateClaimsIdentity(List<Claim> claims)
        {
            var claimsIdentityTest = new ClaimsIdentity();

            foreach (var claim in claims)
            {
                claimsIdentityTest.AddClaim(claim);
            }

            return claimsIdentityTest;
        }      

        public string GenerateToken(string username, int expireMinutes = 15)
        {
            
            //var account = _accountRepository.GetSingle(acc => acc.UserName == username);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("username", username),
                new Claim("password", "aaaaaaaaa"),
                new Claim("application", "ecs"),
                new Claim("roleType", "public")
            }, "Custom");

            var now = DateTime.UtcNow;

            var symmetricKey = Convert.FromBase64String(Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                IssuedAt = now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!(tokenHandler.ReadToken(token) is JwtSecurityToken))
                return null;

            var symmetricKey = Encoding.UTF8.GetBytes(Secret);   

            // The checks that occur during validation of the JWT.
            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            // The JwtSecurityTokenHandler will check all of the validation parameters to ensure
            // the Jwt is acceptable to use.
            var principal = tokenHandler.ValidateToken(token, validationParameters, out var _);

            return principal;
        }

        public bool ValidateToken(string token, out string username)
        {
            throw new NotImplementedException();
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

        public string GetAccessToken(HttpRequestMessage request)
        {
            return request.Headers.Authorization.Parameter;
        }

        public Claim GetClaim(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal) principal;
            return claimsPrincipal.FindFirst(claimType);
        }

        public string GetClaimValue(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal) principal;
            return claimsPrincipal.FindFirst(claimType).Value;
        }
    }
}
