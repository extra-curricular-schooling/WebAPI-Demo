using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class SaltSecurityAnswerLogic
    { 
        private readonly ISaltSecurityAnswerRepository _saltSecurityAnswerRepository;

        public SaltSecurityAnswerLogic()
        {
            _saltSecurityAnswerRepository = new SaltSecurityAnswerRepository();
        }

        public SaltSecurityAnswerLogic(ISaltSecurityAnswerRepository saltsecurityAnswerRepository)
        {
            _saltSecurityAnswerRepository = saltsecurityAnswerRepository;
        }

        public void Create(SaltSecurityAnswer saltSecurity)
        {
            _saltSecurityAnswerRepository.Insert(saltSecurity);
        }

        public List<SaltSecurityAnswer> GetAllByUsername(string username)
        {
            List<SaltSecurityAnswer> saltSecurityAnswers = _saltSecurityAnswerRepository.SearchFor(s => s.UserName == username).ToList();

            return saltSecurityAnswers;
        }

        public SaltSecurityAnswer GetSaltAnswer(string username)
        {
            return _saltSecurityAnswerRepository.GetSingle(partial => partial.UserName == username);
        }

        public void Update(SaltSecurityAnswer saltSecurityAnswer)
        {
            _saltSecurityAnswerRepository.Update(saltSecurityAnswer);
        }

        public bool Exists(string username)
        {
            return _saltSecurityAnswerRepository.Exists(acc => acc.UserName == username);
        }
    }
}
