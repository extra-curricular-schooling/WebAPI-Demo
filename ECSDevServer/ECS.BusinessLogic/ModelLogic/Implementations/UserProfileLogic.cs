using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class UserProfileLogic
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileLogic()
        {
            _userProfileRepository = new UserProfileRepository();
        }

        public UserProfileLogic(IUserProfileRepository saltRepository)
        {
            _userProfileRepository = saltRepository;
        }

        public void Create(UserProfile userProfile)
        {
            _userProfileRepository.Insert(userProfile);
        }

        public UserProfile GetSingle(string email)
        {
            return _userProfileRepository.GetSingle(profile => profile.Email == email);
        }

        public IList<UserProfile> GetAll(string username)
        {
            return _userProfileRepository.GetAll();
        }

        public void Update(UserProfile userProfile)
        {
            _userProfileRepository.Update(userProfile);
        }

        public void Delete(UserProfile userProfile)
        {
            _userProfileRepository.Delete(userProfile);
        }
    }
}
