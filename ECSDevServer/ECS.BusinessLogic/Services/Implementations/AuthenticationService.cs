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

        public void CheckBadAccessTokens(string token)
        {
            var badAccessTokens = _badAccessTokenLogic.GetBadAccessTokens(token);

            // Check the Bad Tokens to ensure this hasn't been seen before.
            if (badAccessTokens.Count > 0)
            {
                throw new UnauthorizedAccessException("Malformed Token");
            }
        }

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

        public void InsertExpiredAccessToken(string token, bool hasReuse)
        {
            _expiredAccessTokenLogic.Create(new ExpiredAccessToken(token, hasReuse));
        }

        public void InsertBadAccessToken(string token)
        {
            _badAccessTokenLogic.Create(new BadAccessToken(token));
        }


    }
}
