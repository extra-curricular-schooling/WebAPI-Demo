using System;
using Xunit;
using Moq;
using ECS.DTO;
using ECS.WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using System.Collections.Generic;

namespace ECS.WebAPI.Tests
{
    public class RegistrationControllerTests
    {
        public class GetRegistration
        {

        }
        public class PostRegistration
        {
            private static AccountRegistrationDTO account = new AccountRegistrationDTO
            {
                FirstName = "Scott",
                LastName = "Roberts",
                Username = "sroberts",
                Email = "s.e.roberts0@gmail.com",
                Password = "fuck",
                Address = "34234 go away",
                City = "Los Alamitos",
                State = "CA",
                ZipCode = 90720,
                SecurityQuestions = new List<string>(),
                SecurityAnswers = new List<string>()
            };

            [Fact]
            public void ReturnOkResponse()
            {
                // Arrange

                    // Mock the Repository we will use in our Controller
                
                    //var mockRepository = new Mock<IProductRepository>();
                    //mockRepository.Setup(x => x.GetById(42))
                    //    .Returns(new Product { Id = 42 });

                // Pass the repository into the controller to initialize it.
                var controller = new RegistrationController();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                IHttpActionResult actionResult = controller.PostRegistration(account);

                // Assert
                Assert.IsType<OkResult>(actionResult);
            }
        }
        public class SayOK
        {
            [Fact]
            public void ReturnOK()
            {
                // Pass the repository into the controller to initialize it.

                // Arrange
                var controller = new RegistrationController();

                // Act
                IHttpActionResult actionResult = controller.SayOK();

                // Assert
                Assert.IsType<OkResult>(actionResult);
            }
        }

    }
}
