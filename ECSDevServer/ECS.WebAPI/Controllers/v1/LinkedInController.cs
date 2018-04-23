using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.Constants.Network;
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
    //[AuthorizeRequired("canShareLinkedIn", Roles = "Scholar")]
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

        // GET: LinkedIn]
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

            string jwtToken = Request.Headers.Authorization.Parameter;
            string username = "";
            if (!JwtManager.Instance.ValidateToken(jwtToken, out username))
            {
                if (!JwtManager.Instance.ValidateExpiredToken(jwtToken, out username)) {
                    return Unauthorized();
                }
            }

            LinkedInAccessToken access;

            try
            {
                if (_linkedinLogic.CheckForLinkedInAccessToken(username))
                {
                    access = _linkedinLogic.GetLinkedInAccessToken(username);
                    if (_linkedinLogic.CheckForExpiredLinkedInAccessToken(access))
                    {
                        return BadRequest("ERR7");
                    }
                }
                else
                {
                    return BadRequest("ERR1");
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            var result = _linkedInControllerLogic.SharePost(access, postData);
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