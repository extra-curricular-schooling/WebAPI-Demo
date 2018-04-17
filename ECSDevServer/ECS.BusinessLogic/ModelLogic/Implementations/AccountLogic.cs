using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.DTO;
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
    }
}
