using ECS.Models;
using ECS.Repositories;
using ECS.WebAPI.Filters.AuthenticationFilters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using ECS.WebAPI.Filters.AuthorizationFilters;
using ECS.DTO;
using ECS.Security.AccessTokens.Jwt;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("LinkedIn")]
    public class LinkedInController : ApiController
    {

        #region Constants and fields
        private const string _defaultAccessGateway = "https://api.linkedin.com/v1/";
        private readonly IJAccessTokenRepository _jAccessTokenRepository = new JAccessTokenRepository();
        private readonly ILinkedInAccessTokenRepository _linkedInAccessTokenRepository = new LinkedInAccessTokenRepository();
        #endregion

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
                if (_linkedInAccessTokenRepository.Exists(d => d.UserName == username, d => d.Account))
                {
                    access = _linkedInAccessTokenRepository.GetSingle(d => d.UserName == username, d => d.Account);
                    if (access.TokenCreation.AddDays(60).CompareTo(DateTime.Now.ToUniversalTime()) <= 0 || access.Expired == true)
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

            var requestUrl = _defaultAccessGateway + "people/~/shares?format=json";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.Host = "api.linkedin.com";

            //Build Header.
            var requestHeaders = new NameValueCollection
            {
                {"x-li-format", "json" },
                {"Authorization", "Bearer " + access.Value}, //It is important "Bearer " is included with the access token here.
            };

            webRequest.Headers.Add(requestHeaders);

            //Build JSON request.
            var jsonMsg = new
            {
                comment = postData.Comment,
                content = new Dictionary<string, string>
                {
                    { "title", postData.Title },
                    { "description", postData.Description },
                    { "submitted-url", postData.SubmittedUrl },
                    { "submitted-image-url", "https://media-exp2.licdn.com/media/AAMABABqAAIAAQAAAAAAAA7yAAAAJGU1OTQ2NGFlLTNjNzEtNGZjOS04NjVkLWIxNjQ4NTY5ZjNlYw.png" }
                },
                visibility = new
                {
                    code = postData.Code
                }
            };

            var requestJson = new JavaScriptSerializer().Serialize(jsonMsg);

            using (var s = webRequest.GetRequestStream())
            {
                var sw = new StreamWriter(s);
                sw.Write(requestJson);
            }
            

            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var responseStream = webResponse.GetResponseStream();
                    if (responseStream == null || webResponse.StatusCode != HttpStatusCode.Created)
                        return new StatusCodeResult(webResponse.StatusCode, new HttpRequestMessage());

                    using (var reader = new StreamReader(responseStream))
                    {
                        var response = reader.ReadToEnd();
                        var json = JObject.Parse(response);
                        var updateKey = json.Value<string>("updateKey");
                        var updateUrl = json.Value<string>("updateUrl");

                        access.Expired = true;
                        _linkedInAccessTokenRepository.Update(access);

                        return Json(new { UpdateKey = updateKey, UpdateUrl = updateUrl });
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}