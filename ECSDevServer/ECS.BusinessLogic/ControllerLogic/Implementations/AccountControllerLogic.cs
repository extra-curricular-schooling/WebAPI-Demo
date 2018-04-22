using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class AccountControllerLogic
    {
        public AccountLogic accountLogic = new AccountLogic();
        public InterestTagLogic interestTagLogic = new InterestTagLogic();

        public void RegisterAccount(RegistrationDTO registrationDto)
        {
            // Create all other objects that need to be added when making an account.

            var account = new Account
            {
                AccountStatus = true,
                AccountTags = null,
                Email = registrationDto.Email,
                FirstTimeUser = false,
                Password = registrationDto.Password,
                Points = 0,
                // SaltSecurityAnswers
                // SecurityAnswers
                SuspensionTime = DateTime.UtcNow,
                UserName = registrationDto.Username
            };
        }

        public List<string> ListAllInterestTags(IList<InterestTag> interests) 
        {
            List<string> interestTags = new List<string>();
            foreach (var tag in interests)
            {
                interestTags.Add(tag.TagName);
            }
            return interestTags;
        }

        public List<string> GetUserInterestTags(Account account)
        {
            List<string> userInterests = new List<string>();
            foreach (var Tag in account.AccountTags)
            {
                userInterests.Add(Tag.TagName);
            }

            return userInterests;
        }
    }
}
