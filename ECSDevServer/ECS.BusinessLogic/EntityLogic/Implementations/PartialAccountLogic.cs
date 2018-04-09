using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.EntityLogic.Implementations
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
    }
}
