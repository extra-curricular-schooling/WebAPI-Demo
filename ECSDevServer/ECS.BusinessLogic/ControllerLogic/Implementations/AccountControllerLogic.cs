using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class AccountControllerLogic
    {
        #region Fields and constants
        private readonly InterestTagLogic _interestTagLogic;
        private readonly AccountLogic _accountLogic;
        private readonly SaltLogic _saltLogic;
        #endregion

        public AccountControllerLogic ()
        {
            _accountLogic = new AccountLogic();
            _saltLogic = new SaltLogic();
            _interestTagLogic = new InterestTagLogic();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        public string GetUsername(string authHeader)
        {
            string accessTokenFromRequest = "";
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader.ToString());

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("bearer",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    accessTokenFromRequest = authHeaderVal.Parameter;
                }
            }

            // get the access token
            // accessTokenFromRequest = actionContext.Request.Headers.Authorization.ToString();

            string username = "";
            if (JwtManager.Instance.ValidateToken(accessTokenFromRequest, out username))
            {
                return username;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="salt"></param>
        /// <param name="desiredPassword"></param>
        public void ChangePassword (Account account, Salt salt, string desiredPassword)
        {
            var pSalt = HashService.Instance.CreateSaltKey();
            var newPassword = HashService.Instance.HashPasswordWithSalt(pSalt, desiredPassword, true);
            salt.PasswordSalt = pSalt;
            account.Password = newPassword;
            _saltLogic.Update(salt);
            _accountLogic.Update(account);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account accountRetrieval(string username)
        {
            return _accountLogic.IncludeAccountTags(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<InterestTag> RetrieveInterestTags()
        {
            return _interestTagLogic.GetAllInterestTags();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interests"></param>
        /// <returns></returns>
        public List<string> ListAllInterestTags(IList<InterestTag> interests) 
        {
            List<string> interestTags = new List<string>();
            foreach (var tag in interests)
            {
                interestTags.Add(tag.TagName);
            }
            return interestTags;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
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
