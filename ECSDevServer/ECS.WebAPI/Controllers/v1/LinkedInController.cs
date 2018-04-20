using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ModelLogic.Implementations;
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
        // GET: LinkedIn]
        [AuthenticationRequired]
        [HttpPost]
        [Route("SharePost")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
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
                if (LinkedinLogic.Instance.CheckForLinkedInAccessToken(username))
                {
                    access = LinkedinLogic.Instance.GetLinkedInAccessToken(username);
                    if (LinkedinLogic.Instance.CheckForExpiredLinkedInAccessToken(access))
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

            var result = LinkedinLogic.Instance.SharePost(access, postData);
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