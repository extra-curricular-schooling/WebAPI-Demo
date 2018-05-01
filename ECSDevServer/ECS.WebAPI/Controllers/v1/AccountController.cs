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
using ECS.WebAPI.Filters.AuthorizationFilters;
using ECS.Constants.Security;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Account")]
    //[AuthorizeRequired(ClaimValues.Scholar)]
    public class AccountController : ApiController
    {
        #region Constants and fields
        private readonly AccountControllerLogic _accountControllerLogic;
        private readonly AccountLogic _accountLogic;
        private readonly JAccessTokenLogic _jAccessTokenLogic;
        private readonly SaltLogic _saltLogic;
        private readonly UserProfileLogic _userProfileLogic;
        private readonly ZipLocationLogic _zipLocationLogic;
        #endregion

        public AccountController()
        {
            _accountControllerLogic = new AccountControllerLogic();
            _accountLogic = new AccountLogic();
            _jAccessTokenLogic = new JAccessTokenLogic();
            _saltLogic = new SaltLogic();
            _userProfileLogic = new UserProfileLogic();
            _zipLocationLogic = new ZipLocationLogic();
        }

        /// <summary>
        /// Allows a user to change their current password.
        /// </summary>
        /// <param name="accountPasswordChangeDTO">
        /// Data transfer object containing the username, current password, and desired new password
        /// of an account
        /// </param>
        /// <returns>
        /// A response containing one of the follow:
        /// - Success: (Valid credentials)
        ///     200 status code
        ///         Message will read 'Password changed.
        /// - Failure:
        ///     400 status code
        ///         Data provided is invalid.
        ///     401 status code
        ///         Upon invalid credentials.
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [AuthorizeRequired(ClaimValues.CanEditInformation)]
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
                return Unauthorized();
            }

            if (!_saltLogic.Exists(accountPasswordChangeDTO.Username))
            {
                return Unauthorized();
            }

            Salt salt;
            try
            {
                salt = _saltLogic.GetSalt(accountPasswordChangeDTO.Username);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            // Check app DB for user.
            Account account;
            try
            {
                account = _accountLogic.GetSingle(accountPasswordChangeDTO.Username);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            if (account.Password == HashService.Instance.HashPasswordWithSalt(salt.PasswordSalt, accountPasswordChangeDTO.Password, true))
            {
                _accountControllerLogic.ChangePassword(account, salt, accountPasswordChangeDTO.NewPassword);
            }
            else
            {
                return Unauthorized();
            }

            return Ok("Password changed.");
        }

        /// <summary>
        /// Returns the interest tags from the DB to fill in the checkboxes
        /// </summary>
        /// <returns> A list of InterestTag Names</returns>
        [AuthorizeRequired(ClaimValues.CanEditInformation)]
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

        /// <summary>
        /// Renews the user's Json Web Token.
        /// </summary>
        /// <returns>
        /// A response containing one of the following:
        /// - Success: (Valid JWT)
        ///     200 status code
        ///         Message body containing new JWT token
        /// - Failure:
        ///     401 status code
        ///         The JWT token is either expired, invalid, or is missing
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [HttpGet]
        [Route("RenewToken")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult RenewToken()
        {
            string accessTokenFromRequest = "";
            // Check authorization header
            if (Request.Headers.Authorization.ToString() != null)
            {
                var authHeader = Request.Headers.Authorization;
                // Retrieve JWT from authorization header
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

                string username = "";
                // Obtain username from JWT if it is valid
                if (JwtManager.Instance.ValidateToken(accessTokenFromRequest, out username))
                {
                    JAccessToken accessToken = _jAccessTokenLogic.GetJAccessToken(username);
                    // Make sure the given username has an existing JWT token
                    if (accessToken != null)
                    {
                        string accessTokenStored = accessToken.Value;
                        // Compare the stored JWT to the given JWT to ensure they are the same
                        if (accessTokenFromRequest == accessTokenStored)
                        {
                            accessToken.DateTimeIssued = DateTime.UtcNow;
                            string token = JwtManager.Instance.GenerateToken(username);
                            accessToken.Value = token;
                            // Update store with new JWT value
                            _jAccessTokenLogic.Update(accessToken);
                            return Json(new { AuthToken = token });
                        }
                        else
                        {
                            return Unauthorized();
                        }
                    }
                    // An existing JWT token was not found for the given username
                    else
                    {
                        return Unauthorized();
                    }
                }
                // JWT was not valid
                else
                {
                    return Unauthorized();
                }
            }
            // Authorization header is empty
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Returns a user's name and address.
        /// </summary>
        /// <returns>
        /// A response containing one of the following:
        /// - Success: (Valid credentials)
        ///     200 status code
        ///         Message body containing name and address.
        /// - Failure:
        ///     401 status code
        ///         Invalid credentials.
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [AuthorizeRequired(ClaimValues.CanEditInformation)]
        [HttpGet]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        [Route("GetUserInfo")]
        public IHttpActionResult GetUserInfo()
        {
            // Check for valid JWT
            string username = _accountControllerLogic.GetUsername(Request.Headers.Authorization.ToString());
            if (username != null)
            {
                // Check for account with the given username
                if (_accountLogic.Exists(username))
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
                // Account with given username does not exist
                else
                {
                    return Unauthorized();
                }
            }
            // Invalid JWT
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Update a user's first and last name.
        /// </summary>
        /// <param name="userInfoDTO">
        /// Data transfer object containing the new values for the user's first and last name
        /// </param>
        /// <returns>
        /// A response contain one of the following:
        /// - Success: (Valid credentials)
        ///     200 status code
        ///         Name was successfully changed
        /// - Failure:
        ///     401 status code
        ///         Invalid JWT
        /// </returns>
        [HttpPost]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [Route("PostUserInfo")]
        [AuthorizeRequired(ClaimValues.CanEditInformation)]
        public IHttpActionResult PostUserInfo(UserInfoDTO userInfoDTO)
        {
            // Check for valid JWT
            string username = _accountControllerLogic.GetUsername(Request.Headers.Authorization.ToString());
            if (username != null)
            {
                // Check for account with given username
                if (_accountLogic.Exists(username))
                {
                    var account = _accountLogic.GetByUsername(username);
                    string email = account.Email;
                    var user = _userProfileLogic.GetSingle(email);
                    user.FirstName = userInfoDTO.FirstName;
                    user.LastName = userInfoDTO.LastName;
                    _userProfileLogic.Update(user);
                    return Ok();
                }
                // No account with given username
                else
                {
                    return Unauthorized();
                }
            }
            // Jwt is missing or not valid
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Add or modify a user's address
        /// </summary>
        /// <param name="zipLocationDTO">
        /// Data transfer object containing the pertinent information to create a new zipLocation object
        /// </param>
        /// <returns>
        /// A response contains one of the following:
        /// - Success: (Valid JWT)
        ///     200 status code
        ///         Successfully added/modified an address
        /// - Failure:
        ///     400 status code
        ///         The user does not contain an address with the provided id.
        ///     401 status code
        ///         Invalid JWT.
        /// </returns>
        [HttpPost]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [Route("PostUserAddress")]
        [AuthorizeRequired(ClaimValues.CanEditInformation)]
        public IHttpActionResult PostUserAddress (ZipLocationDTO zipLocationDTO)
        {
            // Check Authorization header for valid Jwt.
            string username = _accountControllerLogic.GetUsername(Request.Headers.Authorization.ToString());
            if (username != null)
            {
                var account = _accountLogic.GetByUsername(username);
                string email = account.Email;
                var user = _userProfileLogic.GetSingle(email);
                // If a zipLocation id was provided
                if (zipLocationDTO.ZipCodeID >= 0)
                {
                    // Iterate through all the user's addresses
                    foreach (var address in user.ZipLocations)
                    {
                        // Match the provided id with one of the user's addresses
                        if (address.ZipCodeId == zipLocationDTO.ZipCodeID)
                        {
                            // Update
                            address.Address = zipLocationDTO.Address;
                            address.City = zipLocationDTO.City;
                            address.State = zipLocationDTO.State;
                            address.ZipCode = zipLocationDTO.ZipCode;
                            _zipLocationLogic.Update(address);
                            return Ok();
                        }
                    }
                    // If this point is reached it means the id provided does not
                    // pertain to the given user
                    return BadRequest("No records were updated.");
                }
                // No valid zipLocation id was provided, so a new entry is required
                else
                {
                    ZipLocation zipLocation = new ZipLocation {
                        Address = zipLocationDTO.Address,
                        City = zipLocationDTO.City,
                        State = zipLocationDTO.State,
                        ZipCode = zipLocationDTO.ZipCode
                    };
                    user.ZipLocations.Add(zipLocation);
                    _userProfileLogic.Update(user);
                    return Ok();
                }
            }
            // Jwt is either invalid or missing
            else
            {
                return Unauthorized();
            }
        }
    }
}