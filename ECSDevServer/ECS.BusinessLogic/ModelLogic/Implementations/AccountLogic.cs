using System.Linq;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class AccountLogic
    {
        private readonly IAccountRepository _accountRepository;

        public AccountLogic()
        {
            _accountRepository = new AccountRepository();
        }

        public AccountLogic(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Create(Account account)
        {
            _accountRepository.Insert(account);
        }

        public Account GetSingle(string username)
        {
            return _accountRepository.GetSingle(partial => partial.UserName == username);
        }

        public Account IncludeAccountTags(string username)
        {
            return _accountRepository.GetSingle(x => x.UserName == username, x => x.AccountTags);
        }

        public Account GetByEmail(string email)
        {
            return _accountRepository.GetSingle(partial => partial.Email == email);
        }

        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }

        public bool Exists(string username)
        {
            return _accountRepository.Exists(acc => acc.UserName == username);
        }

        public bool EmailExists(string email)
        {
            return _accountRepository.Exists(acc => acc.Email == email);
        }

        public Account GetByUsername (string username)
        {
            var accountQueryable = _accountRepository.SearchFor(acc => acc.UserName == username);
            return accountQueryable.FirstOrDefault();
        }
    }
}
