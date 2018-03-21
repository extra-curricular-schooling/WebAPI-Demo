using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using ECS.Repositories;
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

        public string GenerateToken(string username, int expireMinutes = 15)
        {
            // var account = accountRepository.GetById(username);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("username", username),
                //new Claim("password", account.Password),
                new Claim("password", "pass"),
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
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken))
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    // Should be true?
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var _);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
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

        public string GetJwtFromAuthorizationHeader(HttpRequestMessage request)
        {
            return request.Headers.Authorization.Parameter;
        }

        public Claim GetClaim(string token, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var principal = GetPrincipal(token);
            return principal.FindFirst(claimType);
        }

        public string GetClaimValue(string token, string claimType)
        {
            var principal = GetPrincipal(token);
            return principal.FindFirst(claimType).Value;
        }
    }
}
