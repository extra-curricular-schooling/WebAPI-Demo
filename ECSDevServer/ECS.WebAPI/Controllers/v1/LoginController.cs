﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.Constants.Network;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Filters.AuthorizationFilters;
using ECS.WebAPI.Transformers;

namespace ECS.WebAPI.Controllers.v1
{
    [RequireHttps]
    [RoutePrefix("v1/Login")]
    public class LoginController : ApiController
    {
        #region Constants and Fields
        private readonly IPartialAccountRepository _partialAccountRepository = new PartialAccountRepository();
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        private readonly IJAccessTokenRepository _jwtRepository = new JAccessTokenRepository();
        private readonly ISaltRepository _saltRepository = new SaltRepository();
        private readonly SsoControllerLogic _ssoControllerLogic = new SsoControllerLogic();
        #endregion

        /// <summary>
        /// Authenticates a user based on the given username and password.
        /// </summary>
        /// <param name="credentials">
        /// Data transfer object containing the provided username and password of an individual.
        /// </param>
        /// <returns>
        /// A response containing one of the following:
        /// - Success: (Valid credentials)
        ///     200 status code 
        ///         Body contains a Json Web Token (JWT)
        ///         containing the user's requested user info.
        /// - Failure: 
        ///     400 status code 
        ///         Upon suspended account with 'SUSPENDED' message
        ///         Data provided is invalid
        ///     401 status code
        ///         Upon invalid credentials.
        /// </returns>
        /// <remarks>Author: Luis Pedroza-Soto</remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("Submit")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult Submit(AccountCredentialDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            // Checks for valid model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check to make they are not a new SSO user
            if (_partialAccountRepository.Exists(d => d.UserName == credentials.Username))
            {
                var transformer = new SsoLoginTransformer();
                var ssoLoginDto = transformer.Fetch(credentials);
                var response = _ssoControllerLogic.Login(ssoLoginDto);
                return ResponseMessage(response);
            }

            // Proccess any other information.
            if (!_accountRepository.Exists(d => d.UserName == credentials.Username))
            {
                return Unauthorized();
            }

            if (!_saltRepository.Exists(d => d.UserName == credentials.Username, d => d.Account))
            {
                return Unauthorized();
            }

            Salt salt;
            try
            {
                salt = _saltRepository.GetSingle(d => d.UserName == credentials.Username, d => d.Account);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            // Check app DB for user.
            Account account;
            try
            {
                account = _accountRepository.GetSingle(d => d.UserName == credentials.Username);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            if (!account.AccountStatus)
            {
                return BadRequest("SUSPENDED");
            }

            // Issue login information
            if (account.Password == HashService.Instance.HashPasswordWithSalt(salt.PasswordSalt, credentials.Password, true))
            {
                var response = new HttpResponseMessage();
                JAccessToken token;
                var claims = (List<AccountType>)account.AccountTypes;
                // JWT token already exists
                if (_jwtRepository.Exists(d => d.UserName == account.UserName, d => d.Account))
                {
                    token = _jwtRepository.GetSingle(d => d.UserName == account.UserName, d => d.Account);
                    token.Value = JwtManager.Instance.GenerateToken(claims);
                    token.DateTimeIssued = DateTime.UtcNow;
                    _jwtRepository.Update(token);
                }
                // JWT does not exist for this user
                else
                {
                    token = new JAccessToken
                    {
                        Value = JwtManager.Instance.GenerateToken(claims),
                        UserName = account.UserName,
                        DateTimeIssued = DateTime.UtcNow
                    };
                    _jwtRepository.Insert(token);
                }

                return Json(new { AuthToken = token.Value });
            }
            // Given password does no match the stored hashed password after being hashed
            else
            {
                return Unauthorized();
            }
        }
    }
}