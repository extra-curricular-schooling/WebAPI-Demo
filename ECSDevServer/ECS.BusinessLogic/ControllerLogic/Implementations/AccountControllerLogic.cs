using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.DTO;
using ECS.Models;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class AccountControllerLogic
    {
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
    }
}
