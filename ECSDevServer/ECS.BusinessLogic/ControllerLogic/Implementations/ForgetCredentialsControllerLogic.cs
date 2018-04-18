using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Models;
using ECS.Security.Hash;
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
        private readonly SaltSecurityAnswerLogic _saltSecurityAnswerLogic;
        private readonly SaltLogic _saltLogic;

        public ForgetCredentialsControllerLogic()
        {
            _accountLogic = new AccountLogic();
            _securityQuestionsAccountLogic = new SecurityQuestionsAccountLogic();
            _saltSecurityAnswerLogic = new SaltSecurityAnswerLogic();
            _saltLogic = new SaltLogic();
        }

        public ForgetCredentialsControllerLogic(AccountLogic accountLogic, SecurityQuestionsAccountLogic securityQuestionsAccountLogic, SaltSecurityAnswerLogic saltSecurityAnswerLogic, SaltLogic saltLogic)
        {
            _accountLogic = accountLogic;
            _securityQuestionsAccountLogic = securityQuestionsAccountLogic;
            _saltSecurityAnswerLogic = saltSecurityAnswerLogic;
            _saltLogic = saltLogic;
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

            var saltSecurityAnswers = _saltSecurityAnswerLogic.GetAllByUsername(answers.Username);
            var securityQuestionsAccounts = _securityQuestionsAccountLogic.GetAllByUsername(answers.Username);


            bool isAllMatched = true;

            // Expensive...
            foreach (var securityQuestionsAccount in securityQuestionsAccounts)
            {
                foreach (var saltSecurityAnswer in saltSecurityAnswers)
                {
                    foreach (var securityQuestion in answers.SecurityQuestions)
                    {
                        if (securityQuestionsAccount.SecurityQuestionID == saltSecurityAnswer.SecurityQuestionID && saltSecurityAnswer.SecurityQuestionID == securityQuestion.Question)
                        {
                            // Use saltSecurityAnswer.SaltValue to hash securityQuestion.Answer
                            var hashedNewAnswer = HashService.Instance.HashPasswordWithSalt(saltSecurityAnswer.SaltValue, securityQuestion.Answer, true);

                            // Check if hashed answer == securityQuestionsAccount.Answer
                            if (hashedNewAnswer != securityQuestionsAccount.Answer)
                            {
                                isAllMatched = false;
                            }
                        }
                    }
                }
            }

            if (!isAllMatched)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Incorrect Answers",
                    StatusCode = HttpStatusCode.Forbidden
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage PasswordSubmission(AccountCredentialDTO credentials)
        {
            // Create new pw salt and hashedPw
            var pSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(pSalt, credentials.Password, true);

            // Update Salt and Account
            var saltModel = _saltLogic.GetSalt(credentials.Username);
            saltModel.PasswordSalt = pSalt;

            var accountModel = _accountLogic.GetSingle(credentials.Username);
            accountModel.Password = hashedPassword;

            try
            {
                _accountLogic.Update(accountModel);
                _saltLogic.Update(saltModel);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                };
            } catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
