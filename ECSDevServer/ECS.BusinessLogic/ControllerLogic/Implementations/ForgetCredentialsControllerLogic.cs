using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class ForgetCredentialsControllerLogic
    {
        private readonly AccountLogic _accountLogic;
        private readonly SecurityQuestionsAccountLogic _securityQuestionsAccountLogic;

        public ForgetCredentialsControllerLogic()
        {
            _accountLogic = new AccountLogic();
            _securityQuestionsAccountLogic = new SecurityQuestionsAccountLogic();
        }

        public ForgetCredentialsControllerLogic(AccountLogic accountLogic, SecurityQuestionsAccountLogic securityQuestionsAccountLogic)
        {
            _accountLogic = accountLogic;
            _securityQuestionsAccountLogic = securityQuestionsAccountLogic;
        }

        public HttpResponseMessage EmailSubmission(string email)
        {
            // Check if email doesn't exist
            if (!_accountLogic.EmailExists(email))
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "No Email Found",
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            var accountModel = _accountLogic.GetByEmail(email);
            var username = new StringContent(accountModel.UserName);

            return new HttpResponseMessage
            {
                Content = username,
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage UsernameSubmission(string username)
        {
            // Check if username doesn't exist
            if (!_accountLogic.Exists(username))
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "No Username Found",
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            var securityQuestionsAccounts = _securityQuestionsAccountLogic.GetAllByUsername(username);
            //var jsonContent = new JavaScriptSerializer().Serialize(securityQuestionsAccounts);
            List<object> objects = new List<object>();
            object temp;

            foreach (var account in securityQuestionsAccounts)
            {
                temp = new
                {
                    account.SecurityQuestion.SecurityQuestionID,
                    account.SecurityQuestion.SecQuestion
                };
                objects.Add(temp);
            }
            var jsonContent = JsonConvert.SerializeObject(objects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            var stringContent = new StringContent(jsonContent);

            return new HttpResponseMessage
            {
                Content = stringContent,
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage AnswersSubmission(AccountPostAnswersDTO answers)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
