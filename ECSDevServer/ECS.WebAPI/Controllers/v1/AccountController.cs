using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.Hash;
using ECS.Constants.Network;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    // [RequireHttps]
    public class AccountController : ApiController
    {
        #region Constants and fields
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly IInterestTagRepository interestTagRepository = new InterestTagRepository();
        private readonly AccountControllerLogic _accountControllerLogic;
        private readonly AccountLogic _accountLogic;
        private readonly SaltLogic _saltLogic;
        #endregion

        public AccountController ()
        {
            _accountControllerLogic = new AccountControllerLogic();
            _accountLogic = new AccountLogic();
            _saltLogic = new SaltLogic();
        }

        // Should this encompass all of the Account related Action Methods:
        // Edit Personal Information
        // Edit Tag information
        // Change Password
        // View Points
        // See time remaining for suspension
        [HttpPost]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword(AccountPasswordChangeDTO accountPasswordChangeDTO)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(accountPasswordChangeDTO);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.
            if (!_accountLogic.Exists(accountPasswordChangeDTO.Username))
            {
                return BadRequest("Invalid credentials.");
            }

            if (!_saltLogic.Exists(accountPasswordChangeDTO.Username))
            {
                return BadRequest("Invalid credentials.");
            }

            Salt salt;
            try
            {
                salt = _saltLogic.GetSalt(accountPasswordChangeDTO.Username);
            }
            catch (Exception)
            {
                return BadRequest("Invalid credentials.");
            }

            // Check app DB for user.
            Account account;
            try
            {
                account = _accountLogic.GetSingle(accountPasswordChangeDTO.Username);
            }
            catch (Exception)
            {
                return BadRequest("Invalid credentials.");
            }

            if (account.Password == HashService.Instance.HashPasswordWithSalt(salt.PasswordSalt, accountPasswordChangeDTO.Password, true))
            {
                _accountControllerLogic.ChangePassword(account, salt, accountPasswordChangeDTO.NewPassword);
            }
            else
            {
                return BadRequest("Invalid credentials.");
            }

            return Ok("Password changed.");
        }

        /// <summary>
        /// Returns the interest tags from the DB to fill in the checkboxes
        /// </summary>
        /// <returns> A list of InterestTag Names</returns>
        [HttpGet]
        [Route("RetrieveInterestTags")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IList<string> RetrieveInterestTags()
        {
            List<string> interestTags = new List<string>();
            var interests = interestTagRepository.GetAll();
            foreach(var tag in interests)
            {
                interestTags.Add(tag.TagName);
            }
            return interestTags;
        }


        /// <summary>
        /// Returns cuurent interest tags selected by user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns> A list of interest tags based on a user</returns>
        [HttpGet]
        [Route("{username}/GetInterests")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IList<string> GetUserInterests(string username)
        {
            Account account;
            List<string> userInterests = new List<string>();
            account = accountRepository.GetSingle(x => x.UserName == username, x => x.AccountTags);
            foreach (var Tag in account.AccountTags)
            {
               userInterests.Add(Tag.TagName);
            }

            return userInterests;
        }


        /// <summary>
        /// Updates the interest tags of a user
        /// </summary>
        /// <param name="userInterests"></param>
        /// <returns> Ok response </returns>
        [HttpPost]
        [Route("{username}/UpdateInterests")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult UpdateUserInterests(InterestTagsDTO userInterests)
        {
            try
            {
                using (var context = new ECSContext())
                {
                    var account = context.Accounts.Single(x => x.UserName == userInterests.Account);
                    var accountTags = account.AccountTags;
                    foreach (var interest in accountTags.ToList())
                    {
                        if (!userInterests.interestTags.Contains(interest.TagName))
                        {
                            var tag = context.InterestTags.Single(x => x.TagName == interest.TagName);
                            account.AccountTags.Remove(tag);
                        }
                    }

                    foreach (var interest in userInterests.interestTags)
                    {
                        var tag = context.InterestTags.Single(x => x.TagName == interest);
                        if (!account.AccountTags.Contains(tag))
                        {
                            account.AccountTags.Add(tag);
                            tag.AccountUsername.Add(account);
                        }
                    }
                    context.SaveChanges();
                }
                return Ok("Interest tags updated successsfully");
            } catch(Exception)
            {
                return InternalServerError(new Exception("Error has occurred"));
            }
           
        }
    }
}