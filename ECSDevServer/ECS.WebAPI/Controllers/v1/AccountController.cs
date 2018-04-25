using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;
using ECS.Constants.Network;
using ECS.Models.Services.ComplexDBQueries;
using System.Net.Http.Headers;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    public class AccountController : ApiController
    {
        #region Constants and fields
        private readonly AccountControllerLogic _accountControllerLogic;
        private readonly AccountLogic _accountLogic;
        private readonly JAccessTokenLogic _jAccessTokenLogic;
        private readonly SaltLogic _saltLogic;
        private readonly UserProfileLogic _userProfileLogic;
        #endregion

        public AccountController ()
        {
            _accountControllerLogic = new AccountControllerLogic();
            _accountLogic = new AccountLogic();
            _jAccessTokenLogic = new JAccessTokenLogic();
            _saltLogic = new SaltLogic();
            _userProfileLogic = new UserProfileLogic();
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
        [Route("UpdateUserInterests")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult UpdateUserInterests(InterestTagsDTO userInterests)
        {
            UpdateUserInterestTags updateUserInterestTags = new UpdateUserInterestTags();
            var response = updateUserInterestTags.UpdateUserInterests(userInterests);
            IHttpActionResult actionResultResponse = ResponseMessage(response);
            return actionResultResponse;
           
        }

        [HttpGet]
        [Route("RenewToken")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult RenewToken()
        {
            string accessTokenFromRequest = "";
            if (Request.Headers.Authorization.ToString() != null)
            {
                var authHeader = Request.Headers.Authorization;
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
                    JAccessToken accessToken = _jAccessTokenLogic.GetJAccessToken(username);
                    if (accessToken != null)
                    {
                        string accessTokenStored = accessToken.Value;
                        if (accessTokenFromRequest == accessTokenStored)
                        {
                            accessToken.DateTimeIssued = DateTime.UtcNow;
                            string token = JwtManager.Instance.GenerateToken(username);
                            accessToken.Value = token;
                            _jAccessTokenLogic.Update(accessToken);
                            return Json(new { AuthToken = token });
                        }
                        else
                        {
                            return Unauthorized();
                        }
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        [Route("GetUserInfo")]
        public IHttpActionResult GetUserInfo()
        {
            string username = _accountControllerLogic.GetUsername(Request.Headers.Authorization.ToString());
            if (username != null)
            {
                if(_accountLogic.Exists(username))
                {
                    var account = _accountLogic.GetByUsername(username);
                    string email = account.Email;
                    var user = _userProfileLogic.GetSingle(email);
                    var userAddresses = user.ZipLocations;
                    List<object> zipLocations = new List<object>();
                    foreach (var zipLocation in userAddresses)
                    {
                        zipLocations.Add(new { zipLocation.Address, zipLocation.City, zipLocation.State, zipLocation.ZipCode, zipLocation.ZipCodeId });
                    }
                    return Json(new { user.FirstName, user.LastName, zipLocations });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [Route("PostUserInfo")]
        public IHttpActionResult PostUserInfo(UserInfoDTO userInfoDTO)
        {
            string username = _accountControllerLogic.GetUsername(Request.Headers.Authorization.ToString());
            if (username != null)
            {
                if(_accountLogic.Exists(username))
                {
                    var account = _accountLogic.GetByUsername(username);
                    string email = account.Email;
                    var user = _userProfileLogic.GetSingle(email);
                    user.FirstName = userInfoDTO.FirstName;
                    user.LastName = userInfoDTO.LastName;
                    _userProfileLogic.Update(user);
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}