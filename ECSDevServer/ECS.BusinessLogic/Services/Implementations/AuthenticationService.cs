using System;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Models;

namespace ECS.BusinessLogic.Services.Implementations
{
    public class AuthenticationService
    {
        private readonly IExpiredAccessTokenLogic _expiredAccessTokenLogic;
        private readonly IBadAccessTokenLogic _badAccessTokenLogic;
        public AuthenticationService()
        {
            _expiredAccessTokenLogic = new ExpiredAccessTokenLogic();
            _badAccessTokenLogic = new BadAccessTokenLogic();
        }

        /// <summary>
        /// Checks if the blacklisted access token has been saved in our system.
        /// </summary>
        /// <param name="token"></param>
        /// <exception cref="UnauthorizedAccessException">Token appears in database.</exception>
        public void CheckBadAccessTokens(string token)
        {
            // TODO: @Scott Make sure to add comments for not having the responsiblity to check for null token values.

            var badAccessTokens = _badAccessTokenLogic.GetBadAccessTokens(token);

            // Check the Bad Tokens to ensure this hasn't been seen before.
            if (badAccessTokens.Count > 0)
            {
                throw new UnauthorizedAccessException("Malformed Token");
            }
        }

        /// <summary>
        /// Checks if the expired access token has been saved in our system.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="threshold"></param>
        /// <exception cref="UnauthorizedAccessException">Token appears more than the threshold allows.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Threshold is negative.</exception>
        public void CheckExpiredAccessTokens(string token, int threshold)
        {  
            if (threshold <= 0) throw new ArgumentOutOfRangeException(nameof(threshold));

            var expiredAccessTokens = _expiredAccessTokenLogic.GetExpiredAccessTokens(token);
            // Check the database for a reuse of expired tokens.
            if (expiredAccessTokens.Count >= threshold)
            {
                throw new UnauthorizedAccessException("Token Not Usable");
            }
            
        }

        /// <summary>
        /// Wrapper for ExpiredAccessToken model logic insert.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hasReuse"></param>
        public void InsertExpiredAccessToken(string token, bool hasReuse)
        {
            _expiredAccessTokenLogic.Create(new ExpiredAccessToken(token, hasReuse));
        }

        /// <summary>
        /// Wrapper for BadAccessToken model logic insert
        /// </summary>
        /// <param name="token"></param>
        public void InsertBadAccessToken(string token)
        {
            _badAccessTokenLogic.Create(new BadAccessToken(token));
        }
    }
}
