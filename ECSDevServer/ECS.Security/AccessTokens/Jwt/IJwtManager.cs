using System.Security.Claims;

namespace ECS.Security.AccessTokens.Jwt
{
    // Fill in the rest of the comments.
    public interface IJwtManager
    {
        /// <summary>
        /// Creates a JWT
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expireMinutes"></param>
        /// <returns>Token String</returns>
        string GenerateToken(string username, int expireMinutes = 15);
        /// <summary>
        /// Unencrypts the JWT
        /// </summary>
        /// <param name="token"></param>
        /// <returns>The Claims of the JWT</returns>
        ClaimsPrincipal GetPrincipal(string token);
        /// <summary>
        /// Authorization check for a user based on the provided token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <returns>isAuthorized</returns>
        bool ValidateToken(string token, out string username);
    }
}
