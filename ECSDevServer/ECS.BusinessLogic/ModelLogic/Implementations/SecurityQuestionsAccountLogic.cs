using ECS.Models;
using ECS.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class SecurityQuestionsAccountLogic
    {
        private readonly ISecurityQuestionAccountRepository _securityQuestionAccountRepository;

        public SecurityQuestionsAccountLogic()
        {
            _securityQuestionAccountRepository = new SecurityQuestionAccountRepository();
        }

        public SecurityQuestionsAccountLogic(ISecurityQuestionAccountRepository securityQuestionAccountRepository)
        {
            _securityQuestionAccountRepository = securityQuestionAccountRepository;
        }

        public List<SecurityQuestionAccount> GetAllByUsername(string username)
        {
            List<SecurityQuestionAccount> securityQuestionAccounts = _securityQuestionAccountRepository.SearchFor(sQAcc => sQAcc.Username == username).ToList();

            return securityQuestionAccounts;
        }

        public SecurityQuestionAccount GetAccount(string username)
        {
            return _securityQuestionAccountRepository.GetSingle(partial => partial.Username == username);
        }
    }
}
