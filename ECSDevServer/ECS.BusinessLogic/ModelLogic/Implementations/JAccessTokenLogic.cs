using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class JAccessTokenLogic
    {
        private readonly IJAccessTokenRepository _jAccessTokenRepository;

        public JAccessTokenLogic()
        {
            _jAccessTokenRepository = new JAccessTokenRepository();
        }

        public JAccessTokenLogic(IJAccessTokenRepository jAccessTokenRepository)
        {
            _jAccessTokenRepository = jAccessTokenRepository;
        }

        public void Create(JAccessToken jAccessToken)
        {
            _jAccessTokenRepository.Insert(jAccessToken);
        }

        public JAccessToken GetJAccessToken(string username)
        {
            return _jAccessTokenRepository.GetSingle(token => token.UserName == username);
        }

        public bool Exists(string username)
        {
            return _jAccessTokenRepository.Exists(token => token.UserName == username);
        }

        public void Update(JAccessToken jAccessToken)
        {
            _jAccessTokenRepository.Update(jAccessToken);
        }
    }
}
