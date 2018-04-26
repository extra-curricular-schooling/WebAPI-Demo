using System.Linq;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    /// <summary>
    /// Account model business logic wrapper for repository code.
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        public void Create(Account account)
        {
            _accountRepository.Insert(account);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account GetSingle(string username)
        {
            return _accountRepository.GetSingle(partial => partial.UserName == username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account IncludeAccountTags(string username)
        {
            return _accountRepository.GetSingle(x => x.UserName == username, x => x.AccountTags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Account GetByEmail(string email)
        {
            return _accountRepository.GetSingle(partial => partial.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Exists(string username)
        {
            return _accountRepository.Exists(acc => acc.UserName == username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EmailExists(string email)
        {
            return _accountRepository.Exists(acc => acc.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account GetByUsername (string username)
        {
            var accountQueryable = _accountRepository.SearchFor(acc => acc.UserName == username);
            return accountQueryable.FirstOrDefault();
        }
    }
}
