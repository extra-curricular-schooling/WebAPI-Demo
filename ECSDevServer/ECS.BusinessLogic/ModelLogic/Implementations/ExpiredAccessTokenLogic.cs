using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class ExpiredAccessTokenLogic
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

        public bool Exists(string tokenValue)
        {
            return _expiredAccessTokenRepository.Exists(token => token.ExpiredTokenValue == tokenValue);
        }
    }
}
