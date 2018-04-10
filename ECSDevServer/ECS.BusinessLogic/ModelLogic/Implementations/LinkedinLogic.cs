using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class LinkedinLogic : Contracts.ILinkedinLogic
    {
        #region Constants and fields
        private const string _defaultAccessGateway = "https://api.linkedin.com/v1/";
        private readonly ILinkedInAccessTokenRepository _linkedInAccessTokenRepository;
        private static LinkedinLogic instance;
        #endregion

        private LinkedinLogic()
        {
            _linkedInAccessTokenRepository = new LinkedInAccessTokenRepository();
        }

        public static LinkedinLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LinkedinLogic();
                }
                return instance;
            }
        }

        public bool CheckForExpiredLinkedInAccessToken(LinkedInAccessToken token)
        {
            if (token.TokenCreation.AddDays(60).CompareTo(DateTime.Now.ToUniversalTime()) <= 0 || token.Expired == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForLinkedInAccessToken(string username)
        {
            return _linkedInAccessTokenRepository.Exists(d => d.UserName == username, d => d.Account);
        }

        public LinkedInAccessToken GetLinkedInAccessToken(string username)
        {
            try
            {
                return _linkedInAccessTokenRepository.GetSingle(d => d.UserName == username, d => d.Account);
            }
            catch (Exception)
            {
                return null;
            }          
        }

        public bool InsertLinkedInAccessToken(LinkedInAccessToken token)
        {
            try
            {
                _linkedInAccessTokenRepository.Insert(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InvalidateLinkedInAccessToken(LinkedInAccessToken token)
        {
            token.Expired = true;
            return UpdateLinkedInAccessToken(token);
        }

        public Object SharePost(LinkedInAccessToken linkedInAccessToken, LinkedInPostDTO linkedInPostDTO)
        {
            var requestUrl = _defaultAccessGateway + "people/~/shares?format=json";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.Host = "api.linkedin.com";
            webRequest.KeepAlive = true;

            //Build Header.
            var requestHeaders = new NameValueCollection
            {
                {"x-li-format", "json" },
                {"Authorization", "Bearer " + linkedInAccessToken.Value}, //It is important "Bearer " is included with the access token here.
            };

            webRequest.Headers.Add(requestHeaders);

            //Build JSON request.
            var jsonMsg = new
            {
                comment = linkedInPostDTO.Comment,
                content = new Dictionary<string, string>
                {
                    { "title", linkedInPostDTO.Title },
                    { "description", linkedInPostDTO.Description },
                    { "submitted-url", linkedInPostDTO.SubmittedUrl },
                    { "submitted-image-url", "https://media-exp2.licdn.com/media/AAMABABqAAIAAQAAAAAAAA7yAAAAJGU1OTQ2NGFlLTNjNzEtNGZjOS04NjVkLWIxNjQ4NTY5ZjNlYw.png" }
                },
                visibility = new
                {
                    code = linkedInPostDTO.Code
                }
            };

            var requestJson = new JavaScriptSerializer().Serialize(jsonMsg);

            using (var s = webRequest.GetRequestStream())
            {
                var sw = new StreamWriter(s);
                sw.Write(requestJson);
                sw.Flush();
                sw.Close();
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

                        InvalidateLinkedInAccessToken(linkedInAccessToken);

                        return new { UpdateKey = updateKey, UpdateUrl = updateUrl };
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateLinkedInAccessToken(LinkedInAccessToken token)
        {
            try
            {
                _linkedInAccessTokenRepository.Update(token);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
