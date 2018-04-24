using System;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class AccountControllerLogic
    {
        #region Fields and constants
        private readonly AccountLogic _accountLogic;
        private readonly SaltLogic _saltLogic;
        #endregion

        public AccountControllerLogic ()
        {
            _accountLogic = new AccountLogic();
            _saltLogic = new SaltLogic();
        }

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

        public void ChangePassword (Account account, Salt salt, string desiredPassword)
        {
            var pSalt = HashService.Instance.CreateSaltKey();
            var newPassword = HashService.Instance.HashPasswordWithSalt(pSalt, desiredPassword, true);
            salt.PasswordSalt = pSalt;
            account.Password = newPassword;
            _saltLogic.Update(salt);
            _accountLogic.Update(account);
        }
    }
}
