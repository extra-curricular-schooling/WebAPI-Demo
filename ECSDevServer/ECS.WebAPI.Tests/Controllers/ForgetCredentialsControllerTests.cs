using ECS.DTO;
using ECS.WebAPI.Controllers.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace ECS.WebAPI.Tests.Controllers
{
    public class ForgetCredentialsControllerTests
    {
        // private readonly AccountLogic _accountLogic;
        // private readonly SecurityQuestionsAccountLogic _securityQuestionsAccountLogic;
        // private readonly SaltSecurityAnswerLogic _saltSecurityAnswerLogic;
        // private readonly SaltLogic _saltLogic;

        public class GetUsername
        {
            private const string email = "piechual@gmail.com";

            [Fact]
            public void GetReturnsOkResponse()
            {
                // Arrange
                var controller = new ForgetCredentialsController();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.GetUsername(email);

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void GetReturnsConflictResponse()
            {

            }

            [Fact]
            public void GetReturnsInternalServerErrorResponse()
            {

            }
        }

        public class GetSecurityQuestions
        {
            private const string username = "BarneyTheDinosaur123";

            [Fact]
            public void GetReturnsOkResponse()
            {
                // Arrange
                var controller = new ForgetCredentialsController();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.GetSecurityQuestions(username);

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void GetReturnsConflictResponse()
            {

            }
        }

        public class SubmitAnswers
        {
            AccountPostAnswersDTO accountAnswers = new AccountPostAnswersDTO
            {
                Username = "BarneyTheDinosaur123",
                SecurityQuestions = new List<SecurityQuestionDTO>
                {
                    new SecurityQuestionDTO
                    {
                        Question = 2,
                        Answer = "Yes"
                    },
                    new SecurityQuestionDTO
                    {
                        Question = 1,
                        Answer = "No"
                    },
                    new SecurityQuestionDTO
                    {
                        Question = 6,
                        Answer = "Maybe"
                    }
                }
            };

            [Fact]
            public void PostReturnsOkResponse()
            {
                // Arrange
                var controller = new ForgetCredentialsController();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.SubmitAnswers(accountAnswers);

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void PostReturnsForbiddenResponse()
            {

            }
        }

        public class SubmitNewPassword
        {
            AccountCredentialDTO credentials = new AccountCredentialDTO
            {
                Username = "VongVatanak",
                Password = "CECSrocks491!"
            };

            [Fact]
            public void PostReturnsOkResponse()
            {
                // Arrange
                var controller = new ForgetCredentialsController();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.SubmitNewPassword(credentials);

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void PostReturnsInternalServerErrorResponse()
            {

            }
        }
    }
}
