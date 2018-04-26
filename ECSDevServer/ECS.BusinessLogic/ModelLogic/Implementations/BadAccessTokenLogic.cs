using System.Collections.Generic;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    /// <summary>
    /// BadAccessToken model business logic wrapper for repository code.
    /// </summary>
    public class BadAccessTokenLogic : IBadAccessTokenLogic
    {
        private readonly IBadAccessTokenRepository _badAccessTokenRepository;

        public BadAccessTokenLogic()
        {
            _badAccessTokenRepository = new BadAccessTokenRepository();
        }

        public BadAccessTokenLogic(IBadAccessTokenRepository badAccessTokenRepository)
        {
            _badAccessTokenRepository = badAccessTokenRepository;
        }

        public void Create(BadAccessToken badAccessToken)
        {
            _badAccessTokenRepository.Insert(badAccessToken);
        }

        public BadAccessToken GetBadAccessToken(string token)
        {
            return _badAccessTokenRepository.GetSingle(tokenModel => tokenModel.BadTokenValue == token);
        }

        public List<BadAccessToken> GetBadAccessTokens(string token)
        {
            var badAccessTokenQuery = _badAccessTokenRepository.SearchFor(tokenModel => 
                tokenModel.BadTokenValue == token);
            var list = new List<BadAccessToken>(badAccessTokenQuery);
            return list;
        }

        public bool Exists(string token)
        {
            return _badAccessTokenRepository.Exists(tokenModel => tokenModel.BadTokenValue == token);
        }

        public void Update(BadAccessToken badAccessToken)
        {
            _badAccessTokenRepository.Update(badAccessToken);
        }
    }
}
