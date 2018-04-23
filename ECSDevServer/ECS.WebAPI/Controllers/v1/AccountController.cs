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

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
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
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
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

        [Route("{username}/GetInterests")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IList<string> GetUserArticles(string username)
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



        [HttpPost]
        [Route("{username}/UpdateInterests")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult PostUserArticles(InterestTagsDTO userInterests)
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
            } catch(Exception e)
            {
                return InternalServerError(new Exception("Error has occurred"));
            }
           
        }
    }
}