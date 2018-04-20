using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using ECS.Security.Hash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

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


        /// <summary>
        /// Logic takes email from controller and returns username associated with 
        /// that user email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

            // Retrieve username from the user's account by email
            var accountModel = _accountLogic.GetByEmail(email);
            var username = new StringContent(accountModel.UserName);

            // Return successful message
            return new HttpResponseMessage
            {
                Content = username,
                StatusCode = HttpStatusCode.OK
            };
        }


        /// <summary>
        /// Logic takes username from controller and returns the set of security questions
        /// that were set during registration
        /// Security questions are assoicated with username parameter
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

            // Retrieve security questions from user's account by username
            var securityQuestionsAccounts = _securityQuestionsAccountLogic.GetAllByUsername(username);

            // Create a list that only contains needed information: Security Question and ID
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

            // Serialize list as string
            var jsonContent = JsonConvert.SerializeObject(objects, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });

            var stringContent = new StringContent(jsonContent);

            // Return successful message
            return new HttpResponseMessage
            {
                Content = stringContent,
                StatusCode = HttpStatusCode.OK
            };
        }


        /// <summary>
        /// Logic takes posted answers to security questions associated with the user's account
        /// and tests if they match with their stored answers after salting
        /// Request is rejected if answers do not match
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public HttpResponseMessage AnswersSubmission(AccountPostAnswersDTO answers)
        {
            // Retrieve original salts and answers to stored security questions by username
            var saltSecurityAnswers = _saltSecurityAnswerLogic.GetAllByUsername(answers.Username);
            var securityQuestionsAccounts = _securityQuestionsAccountLogic.GetAllByUsername(answers.Username);

            // Bool to test if matched answers pass
            bool isAllMatched = true;

            // Expensive...?
            // Iterate through security questions in account, salts for stored answers, and new answers
            // to look for matching security questions to test if answers also match
            foreach (var securityQuestionsAccount in securityQuestionsAccounts)
            {
                foreach (var saltSecurityAnswer in saltSecurityAnswers)
                {
                    foreach (var securityQuestion in answers.SecurityQuestions)
                    {
                        if (securityQuestionsAccount.SecurityQuestionID == saltSecurityAnswer.SecurityQuestionID && saltSecurityAnswer.SecurityQuestionID == securityQuestion.Question)
                        {
                            // Use stored salt to hash new answer
                            var hashedNewAnswer = HashService.Instance.HashPasswordWithSalt(saltSecurityAnswer.SaltValue, securityQuestion.Answer, true);

                            // Check if new answer matches original answer
                            if (hashedNewAnswer != securityQuestionsAccount.Answer)
                            {
                                isAllMatched = false;
                            }
                        }
                    }
                }
            }

            // Reject user if answers don't match
            if (!isAllMatched)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Incorrect Answers",
                    StatusCode = HttpStatusCode.Forbidden
                };
            }

            // Otherwise return successful message
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }


        /// <summary>
        /// Logic takes new password credentials from controller and updates existing
        /// password and its salt stored in the user's account
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public HttpResponseMessage PasswordSubmission(AccountCredentialDTO credentials)
        {
            // Create new password salt and hash new password
            var pSalt = HashService.Instance.CreateSaltKey();
            var hashedPassword = HashService.Instance.HashPasswordWithSalt(pSalt, credentials.Password, true);

            // Update new salt and password properties
            var saltModel = _saltLogic.GetSalt(credentials.Username);
            saltModel.PasswordSalt = pSalt;

            var accountModel = _accountLogic.GetSingle(credentials.Username);
            accountModel.Password = hashedPassword;

            try
            {
                // Save context
                _accountLogic.Update(accountModel);
                _saltLogic.Update(saltModel);

                // Return if successful
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                };

            } catch (Exception ex)
            {
                // Catch if exception with EF/DB occurs
                return new HttpResponseMessage
                {
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
