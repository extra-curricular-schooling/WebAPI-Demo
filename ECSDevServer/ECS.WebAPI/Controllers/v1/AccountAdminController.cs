using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Network;
using ECS.Constants.Security;
using ECS.DTO;
using ECS.Models;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/AccountAdmin")]
    [EnableCors(CorsConstants.BaseAcceptedOrigins, CorsConstants.BaseAcceptedHeaders, "GET, POST, PUT")]
    [AuthorizeRequired(ClaimValues.CanDeleteUser)]
    public class AccountAdminController : ApiController
    {
        #region Fields and constants
        private readonly AccountLogic _accountLogic;
        #endregion

        public AccountAdminController()
        {
            _accountLogic = new AccountLogic();
        }

        /// <summary>
        /// Grants admin access to a user's account status
        /// </summary>
        /// <param name="usernameDTO">
        /// A way to get the username from the body of the request instead of a query string
        /// </param>
        /// <returns>
        /// - Success: (Valid Username)
        ///     200 status code
        ///         Body contains status of given user
        /// - Failure:
        ///     400 status code
        ///         The given username does not exist
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [HttpPost]
        [Route("SingleScholarAccountInformation")]
        public IHttpActionResult SingleScholarAccountInformation(UsernameDTO usernameDTO)
        {
            Account requestedAccount;
            // Verifying the requested account exists
            if(_accountLogic.Exists(usernameDTO.username))
            {
                requestedAccount = _accountLogic.GetByUsername(usernameDTO.username);
            }
            // The requested account does not exist.
            else
            {
                return BadRequest("The requested account with the given username does not exist!");
            }
            return Json(new { requestedAccount.AccountStatus });
        }

        /// <summary>
        /// Grants admin access to modifying a user's account status
        /// </summary>
        /// <param name="accountStatusDTO">
        /// Data transfer object containing the new status of the account along with the username
        /// </param>
        /// <returns>
        /// One of the following will be returned:
        /// - Success: (Valid username)
        ///     200 status code
        ///         Account status was updated
        /// - Failure:
        ///     400 status code
        ///         Username does not exist
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [HttpPost]
        [Route("ScholarAccountInformation")]
        public IHttpActionResult ScholarAccountInformation(AccountStatusDTO accountStatusDTO)
        {
            // Check model binding
            Validate(accountStatusDTO);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Update info in database.
            try
            {
                Account account;
                // Verifying the requested account exists
                if (_accountLogic.Exists(accountStatusDTO.username))
                {
                    account = _accountLogic.GetByUsername(accountStatusDTO.username);
                }
                // The requested account does not exist.
                else
                {
                    return BadRequest("The requested account with the given username does not exist!");
                }
                account.AccountStatus = accountStatusDTO.accountStatus;
                _accountLogic.Update(account);
            } catch (Exception ex)
            {
                return BadRequest(ex.Source + "\n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
            }

            // Return successful response if update correctly.
            return Ok("Put Account Information");
        }

        [HttpPut]
        [Route("AccountStatus")]
        public IHttpActionResult AccountStatus()
        {
            return Ok("Get Account Status");
        }
    }
}