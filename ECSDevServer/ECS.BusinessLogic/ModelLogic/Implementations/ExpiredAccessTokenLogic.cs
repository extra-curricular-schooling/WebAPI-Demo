using System.Collections.Generic;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class ExpiredAccessTokenLogic : IExpiredAccessTokenLogic
    {
        private readonly IExpiredAccessTokenRepository _expiredAccessTokenRepository;

        public ExpiredAccessTokenLogic()
        {
            _expiredAccessTokenRepository = new ExpiredAccessTokenRepository();
        }

        public ExpiredAccessTokenLogic(IExpiredAccessTokenRepository expiredAccessTokenRepository)
        {
            _expiredAccessTokenRepository = expiredAccessTokenRepository;
        }

        public void Create(ExpiredAccessToken expiredAccessToken)
        {
            _expiredAccessTokenRepository.Insert(expiredAccessToken);
        }

        public ExpiredAccessToken GetExpiredAccessToken(string tokenValue)
        {
            return _expiredAccessTokenRepository.GetSingle(token => token.ExpiredTokenValue == tokenValue);
        }

        public List<ExpiredAccessToken> GetExpiredAccessTokens(string token)
        {
            var tokenQuery = _expiredAccessTokenRepository.SearchFor(model => model.ExpiredTokenValue == token);
            return new List<ExpiredAccessToken>(tokenQuery);
        }

        public bool Exists(string tokenValue)
        {
            return _expiredAccessTokenRepository.Exists(token => token.ExpiredTokenValue == tokenValue);
        }

        public void Update(ExpiredAccessToken expiredAccessToken)
        {
            _expiredAccessTokenRepository.Update(expiredAccessToken);
        }


    }
}
