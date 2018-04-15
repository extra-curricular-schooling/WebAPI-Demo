using System.Collections.Generic;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class PartialAccountSaltLogic
    {
        private readonly IPartialAccountSaltRepository _saltRepository;

        public PartialAccountSaltLogic()
        {
            _saltRepository = new PartialAccountSaltRepository();
        }

        public PartialAccountSaltLogic(IPartialAccountSaltRepository saltRepository)
        {
            _saltRepository = saltRepository;
        }

        public void Create(PartialAccountSalt partialAccountSalt)
        {
            _saltRepository.Insert(partialAccountSalt);
        }

        public PartialAccountSalt GetSingle(string username)
        {
            return _saltRepository.GetSingle(partial => partial.UserName == username);
        }

        public IList<PartialAccountSalt> GetAll(string username)
        {
            return _saltRepository.GetAll();
        }

        public void Update(PartialAccountSalt partialAccountSalt)
        {
            _saltRepository.Update(partialAccountSalt);
        }

        public void Delete(PartialAccountSalt partialAccountSalt)
        {
            _saltRepository.Delete(partialAccountSalt);
        }
    }
}
