using ECS.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
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
        private static AccountRepository _accountRepository;

        // Instance for Singleton Pattern
        private static SsoJwtManager instance;
        #endregion

        private SsoJwtManager()
        {
            _accountRepository = new AccountRepository();
        }

        public static SsoJwtManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SsoJwtManager();
                }
                return instance;
            }
        }

        public string GenerateToken(string username, int expireMinutes = 15)
        {
            var issuer = "https://localhost:44311/";

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("username", username),
                new Claim("application", "ecs"),
                new Claim("roleType", "public")
            }, "Custom");

            var now = DateTime.UtcNow;

            var symmetricKey = Convert.FromBase64String(Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Subject = claimsIdentity,
                IssuedAt = now,
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                NotBefore = now,
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
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
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

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

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
            ClaimsIdentity identity = null;

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
            string tempUsername = string.Copy(username);

            // More validation to check whether username exists in system
            if (!_accountRepository.Exists(d => d.UserName == tempUsername, d => d.User))
            {
                return false;
            }

            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            if (ValidateToken(token, out string username))
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
    }
}
