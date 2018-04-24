using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ECS.DTO.Sso;
using ECS.Repositories;
using ECS.Repositories.Implementations;
using Microsoft.IdentityModel.Tokens;

namespace ECS.Security.AccessTokens.Jwt
{
    public class JwtManager : IJwtManager
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
        private static JwtManager instance;
        #endregion

        private JwtManager()
        {
            _accountRepository = new AccountRepository();
        }

        public static JwtManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JwtManager();
                }
                return instance;
            }
        }

        public string GenerateToken(string username, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://localhost:44311/",
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username), 
                            new Claim(ClaimTypes.Role, "Scholar")
                        }),
                IssuedAt = now,
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                NotBefore = now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature),
            };
            
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
 
            return token;
        }

        public ClaimsPrincipal GetExpiredPrincipal(string token)
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
                    ValidateLifetime = false,
                    // Should be true?
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44311/",
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
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44311/",
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

        public bool ValidateExpiredToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = GetExpiredPrincipal(token);
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
            if (!_accountRepository.Exists(d => d.UserName == tempUsername))
            {
                return false;
            }

            return true;
        }

        public bool ValidateToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = GetPrincipal(token);
            ClaimsIdentity identity = null;

            try
            {
                identity = simplePrinciple.Identity as ClaimsIdentity;
            } catch(Exception ex)
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
            if(!_accountRepository.Exists(d => d.UserName == tempUsername))
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
        public Claim GetClaim(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal)principal;
            return claimsPrincipal.FindFirst(claimType);
        }

        public string GetClaimValue(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal)principal;
            return claimsPrincipal.FindFirst(claimType).Value;
        }
    }
}