using ECS.Models;
using ECS.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class InterestTagLogic
    {
        private readonly IInterestTagRepository _interestTagRepository;

        public InterestTagLogic()
        {
            _interestTagRepository = new InterestTagRepository();
        }

        public InterestTagLogic(IInterestTagRepository interestTagRepository)
        {
            _interestTagRepository = interestTagRepository;
        }

        public void Create(InterestTag interestTag)
        {
            _interestTagRepository.Insert(interestTag);
        }

        //public List<InterestTag> GetAllByUsername(string interestTag)
        //{
        //    List<InterestTag> interestTags = _interestTagRepository.SearchFor(acc => acc.UserName == interestTag).ToList();

        //    return interestTags;
        //}
        public IList<InterestTag> GetAllInterestTags()
        {
            return _interestTagRepository.GetAll();
        }

        public InterestTag GetInterestTag(string interestTag)
        {
            return _interestTagRepository.GetSingle(acc => acc.TagName == interestTag);
        }

        public void Update(InterestTag interestTag)
        {
            _interestTagRepository.Update(interestTag);
        }

        public bool Exists(string interestTag)
        {
            return _interestTagRepository.Exists(acc => acc.TagName== interestTag);
        }
    }
}
