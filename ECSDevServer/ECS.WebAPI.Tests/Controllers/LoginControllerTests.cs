using ECS.DTO;
using ECS.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ECS.WebAPI.Controllers.v1;
using Xunit;

namespace ECS.WebAPI.Tests.Controllers
{
    public class LoginControllerTests
    {
        public class Login
        {
            AccountCredentialDTO credentialsDTO = new AccountCredentialDTO
            {
                Username = "Scott",
                Password = "roberts"
            };
            [Fact]
            public void ReturnsOk()
            {
                // Arrange

                // Mock the Repository we will use in our Controller... Example:
                //var mockRepository = new Mock<IProductRepository>();
                //mockRepository.Setup(x => x.GetById(42))
                //    .Returns(new Product { Id = 42 });

                // Pass the repository into the controller to initialize it.
                var controller = new LoginController
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                // Act
                

                // Assert
                // Assert.IsType<OkResult>();
            }
        }
    }
}

