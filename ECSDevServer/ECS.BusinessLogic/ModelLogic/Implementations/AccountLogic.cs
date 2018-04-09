using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class AccountLogic
    {
        private readonly IAccountRepository _accountRepository;

        public AccountLogic(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void InsertAccount(Account account)
        {
            _accountRepository.Insert(account);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepository.Update(account);
        }

        public void DisableAccount(Account account)
        {
            account.AccountStatus = false;
            _accountRepository.Update(account);
        }

        public void EnableAccount(Account account)
        {
            account.AccountStatus = true;
            _accountRepository.Update(account);
        }
    }
}
