using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class SaltLogic
    {
        private readonly ISaltRepository _saltRepository;

        public SaltLogic()
        {
            _saltRepository = new SaltRepository();
        }

        public SaltLogic(ISaltRepository saltRepository)
        {
            _saltRepository = saltRepository;
        }

        public void Create(Salt salt)
        {
            _saltRepository.Insert(salt);
        }

        public Salt GetSalt(string username)
        {
            return _saltRepository.GetSingle(partial => partial.UserName == username);
        }

        public void Update(Salt salt)
        {
            _saltRepository.Update(salt);
        }

        public bool Exists(string username)
        {
            return _saltRepository.Exists(acc => acc.UserName == username);
        }
    }
}
