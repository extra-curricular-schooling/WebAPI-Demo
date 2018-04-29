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
using ECS.Constants.Security;

namespace ECS.Security.AccessTokens.Jwt
{
    public class SsoJwtManager
    {
        #region Fields
        // Single repository to query users associated with tokens.
        private readonly IPartialAccountRepository _partialAccountRepository;

        // Instance for Singleton Pattern
        private static SsoJwtManager _instance;
        #endregion

        private SsoJwtManager()
        {
            _partialAccountRepository = new PartialAccountRepository();
        }

        /// <summary>
        /// Singleton Instance
        /// </summary>
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

        /// <summary>
        /// Generates a new Jwt Access token based on the Sso Login Dto
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>Token string</returns>
        public string GenerateToken(SsoLoginRequestDTO loginDto)
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimNames.Username, loginDto.Username),
                new Claim(ClaimNames.Password, loginDto.Password),
                new Claim(ClaimNames.RoleType, loginDto.RoleType),
                new Claim(ClaimNames.Application, ClaimValues.Ecs)
            });

            var now = DateTime.UtcNow;

            var symmetricKey = Encoding.UTF8.GetBytes(Secrets.SsoAccessTokenSecret);
            
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal GetPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!(tokenHandler.ReadToken(token) is JwtSecurityToken))
                throw new Exception("Token is not a compatible JwtSecurityToken type");

            var symmetricKey = Encoding.UTF8.GetBytes(Secrets.SsoAccessTokenSecret);   

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

        /// <summary>
        /// Retrieves a list of tokens if multiple tokens are needed from different headers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IList<string> GetJwtsFromHttpHeaders(HttpRequestMessage request)
        {
            var jwtList = new List<string>();
            if (request.Headers.Authorization != null)
            {
                jwtList.Add(request.Headers.Authorization.Parameter);
            }
            return jwtList;
        }

        /// <summary>
        /// Retrieves a Claim from a given Principal
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns>Claim object</returns>
        public Claim GetClaim(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal) principal;
            return claimsPrincipal.FindFirst(claimType);
        }

        /// <summary>
        /// Retrieves a Claim value from a given Principal
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns>Claim value</returns>
        public string GetClaimValue(IPrincipal principal, string claimType)
        {
            // This line is called multiple times during execution... Figure out a way to get it out.
            var claimsPrincipal = (ClaimsPrincipal) principal;
            return claimsPrincipal.FindFirst(claimType).Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public bool HasAcceptedClaims(IPrincipal principal)
        {
            // Read the Request Principal (User), and grab the necessary jwt claims.
            var usernameClaim = GetClaim(principal, "username");
            var passwordClaim = GetClaim(principal, "password");
            var issuedAtClaim = GetClaim(principal, "iat");
            var applicationClaim = GetClaim(principal, "application");
            var applicationClaimValue = applicationClaim.Value.ToLower();
            var isCorrectApp = applicationClaimValue.Equals(ClaimValues.Ecs);

            return usernameClaim != null && passwordClaim != null &&
                   issuedAtClaim != null && isCorrectApp;
        }
    }
}
