using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Network;
using ECS.DTO;
using ECS.Models;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/AccountAdmin")]
    [EnableCors(CorsConstants.BaseAcceptedOrigins, CorsConstants.BaseAcceptedHeaders, "GET, POST, PUT")]
    public class AccountAdminController : ApiController
    {
        #region Fields and constants
        private readonly AccountLogic _accountLogic;
        #endregion

        public AccountAdminController()
        {
            _accountLogic = new AccountLogic();
        }

        // Edit other account information
        // ... look at scope document

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

        // Filter by username??

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