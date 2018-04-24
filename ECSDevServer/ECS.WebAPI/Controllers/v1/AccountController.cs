using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;
using ECS.Constants.Network;
using ECS.Models.Services.ComplexDBQueries;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    public class AccountController : ApiController
    {
        #region Constants and fields
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
            var interests = _accountControllerLogic.RetrieveInterestTags();
            return _accountControllerLogic.ListAllInterestTags(interests);

        }


        /// <summary>
        /// Returns cuurent interest tags selected by user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns> A list of interest tags based on a user</returns>
        [HttpGet]
        [Route("{username}/GetUserInterests")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IList<string> GetUserInterests(string username)
        {
            Account account = _accountControllerLogic.accountRetrieval(username);
            return _accountControllerLogic.GetUserInterestTags(account);
            
        }


        /// <summary>
        /// Updates the interest tags of a user
        /// </summary>
        /// <param name="userInterests"></param>
        /// <returns> Ok response </returns>
        [HttpPost]
        [Route("{username}/UpdateUserInterests")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult UpdateUserInterests(InterestTagsDTO userInterests)
        {
            UpdateUserInterestTags updateUserInterestTags = new UpdateUserInterestTags();
            var response = updateUserInterestTags.UpdateUserInterests(userInterests);
            IHttpActionResult actionResultResponse = ResponseMessage(response);
            return actionResultResponse;
           
        }
    }
}