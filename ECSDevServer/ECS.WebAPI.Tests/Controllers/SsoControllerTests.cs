using Xunit;
using Xunit.Abstractions;
using ECS.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using ECS.Repositories;
using System.Web.Http.Results;
using System;
using ECS.DTO;
using Moq;
using ECS.Models;

namespace ECS.WebAPI.Tests.Controllers
{
    public class SsoControllerTests
    {
        // This is an integration test worthy method because it has so many dependencies
        private static void SetupControllerIntegration(HttpMethod verb,
            ApiController controller, string controllerName, string actionName, int id)
        {
            var url = "https://localhost:44311/" + controllerName + "/" + actionName + "/" + id;
            var request = new HttpRequestMessage(verb, url);
            var config = new HttpConfiguration();
            var route = config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary {
                    { "controller", controllerName },
                    { "action", actionName },
                    { "id", id }
                });
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }
        // ...
        private static void SetupControllerWithoutIdIntegration(HttpMethod verb,
            ApiController controller, string controllerName, string actionName)
        {
            var url = "https://localhost:44311/" + controllerName + "/" + actionName;
            var request = new HttpRequestMessage(verb, url);
            var config = new HttpConfiguration();
            var route = config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary {
                    { "controller", controllerName },
                    { "action", actionName }
                });
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

        public class Login
        {
            private readonly ITestOutputHelper output;

            public Login(ITestOutputHelper output)
            {

                this.output = output;
            }

            // Needed?
            private static void SetupController()
            {

            }

            // Creates a new mocked Controller
            private static void SetupDummyController()
            {
                // This version uses a mock UrlHelper.

                // Arrange
                var mockAccountRepo = new Mock<IAccountRepository>();
                var MockJwtRepo = new Mock<IJAccessTokenRepository>();
                SsoController controller = new SsoController
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                string locationUrl = "https://localhost:44311/Sso/Login";

                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;


            }

            // Is the route acceptable
            [Fact]
            public void RouteIsRecognized()
            {
                // Arrange
                string controllerName = "Sso";
                string actionName = "Login";
                Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                Mock<IJAccessTokenRepository> jwtRepository = new Mock<IJAccessTokenRepository>();
                SsoController controller = new SsoController(accountRepository.Object, jwtRepository.Object);
                SetupControllerWithoutIdIntegration(HttpMethod.Post, controller, controllerName, actionName);

                // Act
                // Make sure that you actually simulate calling a route... might be hard to test.

                // Assert
                output.WriteLine(controller.Request.ToString());
            }

            // Route "items" are spelled differently
            [Theory]
            [InlineData("SSO", "Login")]
            [InlineData("sso", "Login")]
            [InlineData("Sso", "login")]
            public void RouteIsNotRecognized(string controllerName, string actionName)
            {
                // Arrange
                Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                Mock<IJAccessTokenRepository> jwtRepository = new Mock<IJAccessTokenRepository>();
                SsoController controller = new SsoController(accountRepository.Object, jwtRepository.Object);
                SetupControllerWithoutIdIntegration(HttpMethod.Post, controller, controllerName, actionName);

                // Act

                // Assert
                //output.WriteLine(controllerName + "/" + actionName);
            }

            // Does the post work?
            [Fact]
            public void PostReturnsCreatedStatusCode()
            {
                // Arrange
                Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                Mock<IJAccessTokenRepository> jwtRepository = new Mock<IJAccessTokenRepository>();
                // Setup rules for repositories
                var controller = new SsoController(accountRepository.Object, jwtRepository.Object);
                // Need the information from the JWT to work here.

                // Act
                var result = controller.Login();

                // Assert
                output.WriteLine(result.ToString());
                Assert.IsType<OkResult>(result);
            }

            [Theory]
            [InlineData()]
            public void BadPostReturnsBadResponse()
            {

            }

            // NEEDS WORK
            [Fact]
            public void PostSetsLocationHeader()
            {
                // This version uses a mock UrlHelper.
                Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                Mock<IJAccessTokenRepository> jwtRepository = new Mock<IJAccessTokenRepository>();
                // Arrange
                SsoController controller = new SsoController(accountRepository.Object, jwtRepository.Object)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                string locationUrl = "https://localhost:44311/Sso/Login";

                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act
                var response = (HttpResponseMessage)controller.Login();
                output.WriteLine(response.ToString());

                // Assert
                Assert.Equal(locationUrl, response.Headers.Location.AbsoluteUri);
            }

            
            [Fact]
            public void ReturnsJwtTokenWithRedirect()
            {
                // Arrange
                var credential = new AccountCredentialDTO
                {
                    Username = "user",
                    Password = "pass"
                };
                Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                Mock<IJAccessTokenRepository> jwtRepository = new Mock<IJAccessTokenRepository>();
                // This is incorrect right now.
                accountRepository.Setup(x => x.GetById(33)).Returns(new Account
                {
                });
                SsoController controller = new SsoController(accountRepository.Object, jwtRepository.Object);

                // Act

                // Assert

            }

            // Do their login credentials make it to the controller (model binding validated)?

            // Malformed POST body

            // Model data is not mappable 

            // Do I send a successful response back?



            // The following are not the responsiblity of the controller:

            // Check the anti-forgery token
            // Check if CORS is accepted 
            // Different domain
            // Unacceptable Headers
            // Unacceptable HttpVerbs
            // Does this access point allow anonymous access (not logged in yet)
            // Allow Anonymous filter code....
            // Is the data being validated?
            // Non-null values
            // Do I need sanitization here?
            // Is the data access connection open?
            // Do the credentials get saved into the repository/gateway? (Data access response)

        }
        public class Register
        {

        }
    }
}
