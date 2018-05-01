using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Network;
using ECS.Constants.Security;
using ECS.DTO;
using ECS.Models;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Filters.AuthenticationFilters;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("v1/LinkedIn")]
    [AuthorizeRequired(ClaimValues.CanShareLinkedIn)]
    public class LinkedInController : ApiController
    {

        #region Fields and constants
        private readonly LinkedInControllerLogic _linkedInControllerLogic;
        private readonly ILinkedinLogic _linkedinLogic;
        #endregion

        public LinkedInController ()
        {
            _linkedInControllerLogic = new LinkedInControllerLogic();
            _linkedinLogic = new LinkedinLogic();
        }

        /// <summary>
        /// Allows app to post on LinkedIn on behalf of a user
        /// </summary>
        /// <param name="postData">
        /// Data transfer object containing the required components to make a LinkedIn
        /// post
        /// </param>
        /// <returns>
        /// One of the following:
        /// - Success (Vali post info and Jwt)
        ///     200 status code
        ///         Response body contains url to the new post
        /// - Failure:
        ///     400 status code
        ///         "ERR7": Expired LinkedIn token
        ///         "ERR1": No LinkedIn token registered with the user
        ///         Post was rejected by LinkedIn
        ///     401 status code
        ///         The given username broke something
        ///         The jwt is either missing or invalid
        /// </returns>
        /// <remarks>Author: Luis Guillermo Pedroza-Soto</remarks>
        [AuthenticationRequired]
        [HttpPost]
        [Route("SharePost")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult SharePost(LinkedInPostDTO postData)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(postData);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check for valid jwt 
            string jwtToken = Request.Headers.Authorization.Parameter;
            string username = "";
            if (!JwtManager.Instance.ValidateToken(jwtToken, out username))
            {
                return Unauthorized();
            }

            LinkedInAccessToken access;

            try
            {
                // Check to ensure the given user have an access token
                if (_linkedinLogic.CheckForLinkedInAccessToken(username))
                {
                    access = _linkedinLogic.GetLinkedInAccessToken(username);
                    // Ensure token is still valid
                    if (_linkedinLogic.CheckForExpiredLinkedInAccessToken(access))
                    {
                        return BadRequest("ERR7");
                    }
                }
                // The user does not have an access token associated with them
                else
                {
                    return BadRequest("ERR1");
                }
            }
            // The given username broke something thus keep em out
            catch (Exception)
            {
                return Unauthorized();
            }

            // using the post data and the access token, share the post
            var result = _linkedInControllerLogic.SharePost(access, postData);
            // A successful post will not be null
            if (result != null)
            {
                return Json(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}