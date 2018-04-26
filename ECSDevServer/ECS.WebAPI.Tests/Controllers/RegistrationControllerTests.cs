using System;
using Xunit;
using Moq;
using ECS.DTO;
using ECS.WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using System.Collections.Generic;
using ECS.WebAPI.Controllers.v1;
using ECS.Repositories.Implementations;
using ECS.BusinessLogic.ControllerLogic.Implementations;

namespace ECS.WebAPI.Tests
{
    public class RegistrationControllerTests
    {
        public class SubmitRegistration
        {
            private static RegistrationControllerLogic _controllerLogic = new RegistrationControllerLogic();

            private static RegistrationDTO account = new RegistrationDTO
            {
                FirstName = "Kim",
                LastName = "Kardashian",
                Username = "KimKardashian1",
                Email = "kardie@gmail.com",
                Password = "QWERTYqwerty2!",
                Address = "123 W Kanye St",
                City = "Los Angeles",
                State = "CA",
                ZipCode = 90214,
                SecurityQuestions = new List<SecurityQuestionDTO>
                {
                    new SecurityQuestionDTO
                    {
                        Question = 1,
                        Answer = "Yes"
                    },
                    new SecurityQuestionDTO
                    {
                        Question = 4,
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
                var controller = new RegistrationController(_controllerLogic)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                // Act
                var response = controller.SubmitRegistration(account);

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void PostReturnsConflictResponse()
            {

            }

            [Fact]
            public void PostReturnsInternalServerErrorResponse()
            {

            }
        }

        public class SubmitPartialRegistration
        {
            [Fact]
            public void PostReturnsOkResponse()
            {

            }

            [Fact]
            public void PostReturnsConflictResponse()
            {

            }

            [Fact]
            public void PostReturnsBadRequestResponse()
            {

            }

            [Fact]
            public void PostReturnsInternalServerErrorResponse()
            {

            }

            [Fact]
            public void PostReturnsInternalServerErrorResponseIfNoPartialAccountSalt()
            {

            }
        }

        public class GetSecurityQuestions
        {
            private static RegistrationControllerLogic _controllerLogic;

            [Fact]
            public void GetReturnsServiceUnavailableResponse()
            {

            }

            [Fact]
            public void GetReturnsOkResponse()
            {
                // Arrange
                var controller = new RegistrationController(_controllerLogic);
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.GetSecurityQuestions();

                // Assert
                Assert.IsType<OkResult>(response);
            }

            [Fact]
            public void GetReturnsInternalServerErrorResponse()
            {

            }
        }
    }
}


//// Arrange

//// Mock the Repository we will use in our Controller

////var mockRepository = new Mock<IProductRepository>();
////mockRepository.Setup(x => x.GetById(42))
////    .Returns(new Product { Id = 42 });

//// Pass the repository into the controller to initialize it.
//var controller = new RegistrationController
//{
//    Request = new HttpRequestMessage(),
//    Configuration = new HttpConfiguration()
//};

//// Act
//IHttpActionResult actionResult = controller.SubmitRegistration(account);

//// Assert
