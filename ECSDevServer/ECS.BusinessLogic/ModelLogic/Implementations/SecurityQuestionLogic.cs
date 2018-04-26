using ECS.Models;
using ECS.Repositories.Implementations;
using System.Collections.Generic;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class SecurityQuestionLogic
    {
        private readonly ISecurityQuestionRepository _securityQuestionRepository;

        public SecurityQuestionLogic()
        {
            _securityQuestionRepository = new SecurityQuestionRepository();
        }

        public SecurityQuestionLogic(ISecurityQuestionRepository securityQuestionRepository)
        {
            _securityQuestionRepository = securityQuestionRepository;
        }

        public List<SecurityQuestion> GetAllQuestions()
        {
            return (List<SecurityQuestion>)_securityQuestionRepository.GetAll();
        }
    }
}
