using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Models.Services.ComplexDBQueries;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    public class AccountController : ApiController
    {

        AccountControllerLogic accountControllerLogic = new AccountControllerLogic();
        // Should this encompass all of the Account related Action Methods:
        // Edit Personal Information
        // Edit Tag information
        // Change Password
        // View Points
        // See time remaining for suspension
        public IHttpActionResult ChangePassword(AccountPasswordChangeDTO accountPasswordChangeDTO)
        {

            return Ok();
        }

        /// <summary>
        /// Returns the interest tags from the DB to fill in the checkboxes
        /// </summary>
        /// <returns> A list of InterestTag Names</returns>
        [HttpGet]
        [Route("RetrieveInterestTags")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IList<string> RetrieveInterestTags()
        {
            var interests = accountControllerLogic.interestTagLogic.GetAllInterestTags();
            return accountControllerLogic.ListAllInterestTags(interests);

        }


        /// <summary>
        /// Returns cuurent interest tags selected by user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns> A list of interest tags based on a user</returns>
        [HttpGet]
        [Route("{username}/GetUserInterests")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IList<string> GetUserInterests(string username)
        {
            Account account = accountControllerLogic.accountLogic.IncludeAccountTags(username);
            return accountControllerLogic.GetUserInterestTags(account);
            
        }


        /// <summary>
        /// Updates the interest tags of a user
        /// </summary>
        /// <param name="userInterests"></param>
        /// <returns> Ok response </returns>
        [HttpPost]
        [Route("UpdateUserInterests")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult UpdateUserInterests(InterestTagsDTO userInterests)
        {
            UpdateUserInterestTags updateUserInterestTags = new UpdateUserInterestTags();
            var response = updateUserInterestTags.UpdateUserInterests(userInterests);
            IHttpActionResult actionResultResponse = ResponseMessage(response);
            return actionResultResponse;
           
        }
    }
}