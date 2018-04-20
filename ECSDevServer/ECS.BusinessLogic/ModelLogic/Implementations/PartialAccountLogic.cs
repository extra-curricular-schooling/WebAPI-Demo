using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class PartialAccountLogic
    {
        private readonly IPartialAccountRepository _partialAccountRepository;

        public PartialAccountLogic()
        {
            _partialAccountRepository = new PartialAccountRepository();
        }

        public PartialAccountLogic(IPartialAccountRepository partialAccountRepository)
        {
            _partialAccountRepository = partialAccountRepository;
        }

        public void Create(PartialAccount partialAccount)
        {
            _partialAccountRepository.Insert(partialAccount);
        }

        public PartialAccount GetPartialAccount(string username)
        {
            return _partialAccountRepository.GetSingle(partial => partial.UserName == username);
        }

        public bool Exists(string username)
        {
            return _partialAccountRepository.Exists(acc => acc.UserName == username);
        }

        public void Update(PartialAccount partialAccount)
        {
            _partialAccountRepository.Update(partialAccount);
        }

        public void Delete(PartialAccount partialAccount)
        {
            _partialAccountRepository.Delete(partialAccount);
        }
    }
}
