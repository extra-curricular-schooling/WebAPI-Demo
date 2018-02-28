using ECS.DTO;
using ECS.WebAPI.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace ECS.WebAPI.Controllers
{
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [RoutePrefix("LinkedIn")]
    public class LinkedInController : ApiController
    {

        #region Constants and fields
        private const string _defaultAccessGateway = "https://api.linkedin.com/v1/";
        #endregion

        // GET: LinkedIn
        [AllowAnonymous]
        [HttpPost]
        [Route("SharePost")]
        public IHttpActionResult SharePost(LinkedInPostDTO postData)
        {
            string accessToken = Request.Headers.Authorization.ToString();

            var requestUrl = _defaultAccessGateway + "people/~/shares?format=json";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.Host = "api.linkedin.com";

            //Build Header.
            var requestHeaders = new NameValueCollection
            {
                {"x-li-format", "json" },
                {"Authorization", "Bearer " + accessToken}, //It is important "Bearer " is included with the access token here.
            };

            webRequest.Headers.Add(requestHeaders);

            //Build JSON request.
            var jsonMsg = new
            {
                comment = postData.comment,
                content = new Dictionary<string, string>
                {
                    { "title", postData.title },
                    { "description", postData.description },
                    { "submitted-url", postData.submittedurl },
                    { "submitted-image-url", "https://media-exp2.licdn.com/media/AAMABABqAAIAAQAAAAAAAA7yAAAAJGU1OTQ2NGFlLTNjNzEtNGZjOS04NjVkLWIxNjQ4NTY5ZjNlYw.png" }
                },
                visibility = new
                {
                    code = postData.code
                }
            };

            var requestJson = new JavaScriptSerializer().Serialize(jsonMsg);

            using (var s = webRequest.GetRequestStream())
            using (var sw = new StreamWriter(s))
                sw.Write(requestJson);

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