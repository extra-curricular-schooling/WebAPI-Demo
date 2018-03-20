using ECS.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ECS.WebAPI.Services.Security.AccessTokens.Jwt
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
                    RequireExpirationTime = true,
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
            username = null;
            var simplePrinciple = GetPrincipal(token);
            ClaimsIdentity identity;

            try
            {
                identity = simplePrinciple.Identity as ClaimsIdentity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return false;
            }

            if (identity == null)
            {
                return false;
            }

            if (!identity.IsAuthenticated)
            {
                return false;
            }

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            // Cannot use a ref or out string in a lambda expression, thus make a copy
            var tempUsername = string.Copy(username);

            // More validation to check whether username exists in system
            return _accountRepository.Exists(d => d.UserName == tempUsername, d => d.User);
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            if (ValidateToken(token, out var username))
            {
                // based on username to get more information from database in order to build local identity  
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)  
                    // Add more claims if needed: Roles, ...  
                };
                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);
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

        public string GetUsername(string token)
        {
            return GetClaim(token, "username").Value;
        }

        public string GetPassword(string token)
        {
            return GetClaim(token, "password").Value;
        }

        public Tuple<string, string> GetUsernameAndPassword(string token)
        {
            var username = GetClaim(token, "username");
            var password = GetClaim(token, "password");
            return new Tuple<string, string>(username.Value, password.Value);
        }
    }
}
