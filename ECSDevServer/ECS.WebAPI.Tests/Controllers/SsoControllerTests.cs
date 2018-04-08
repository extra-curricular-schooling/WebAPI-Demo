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
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.WebAPI.Controllers.v1;

namespace ECS.WebAPI.Tests.Controllers
{
    public class SsoControllerTests
    {
        private const string Username = "user";
        private const string Password = "pass";

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

        // Make a controller and pass it back.
        // Only use this if you do not need repository functionality in the unit test.
        private static SsoController SetupControllerWithEmptyRepoMocks()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var partialAccountRepository = new Mock<IPartialAccountRepository>();
            var jwtRepository = new Mock<IJAccessTokenRepository>();
            var saltRepository = new Mock<ISaltRepository>();
            var partialAccountSaltRepository = new Mock<IPartialAccountSaltRepository>();
            var expiredAccessTokenRepository = new Mock<IExpiredAccessTokenRepository>();
            var controller = new SsoController(accountRepository.Object, partialAccountRepository.Object, jwtRepository.Object, 
                saltRepository.Object, expiredAccessTokenRepository.Object, partialAccountSaltRepository.Object);
            return controller;
        }

        // TODO: @Scott Test the post methods for SSO registration
        public class PostRegistration
        {

        }

        
        public class PostLogin
        {
            private readonly ITestOutputHelper _output;

            public PostLogin(ITestOutputHelper output)
            {
                _output = output;
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
                var controller = SetupControllerWithEmptyRepoMocks();

                //SetupControllerWithoutIdIntegration(HttpMethod.Post, controller, controllerName, actionName);

                // Act
                // Make sure that you actually simulate calling a route... might be hard to test.

                // Assert
                _output.WriteLine(controller.Request.ToString());
            }

            // Route "items" are spelled differently
            [Theory]
            [InlineData("SSO", "Login")]
            [InlineData("sso", "Login")]
            [InlineData("Sso", "login")]
            public void RouteIsNotRecognized(string controllerName, string actionName)
            {
                // Arrange
                var controller = SetupControllerWithEmptyRepoMocks();

                // Act

                // Assert
                //output.WriteLine(controllerName + "/" + actionName);
            }

            // Does the post work?
            [Fact]
            public void PostReturnsRedirectStatusCode()
            {
                // Arrange

                var controller = SetupControllerWithEmptyRepoMocks();

                // Act
                var result = controller.Login();

                // Assert
                _output.WriteLine(result.ToString());
                Assert.IsType<OkResult>(result);
            }

            [Fact]
            public void BadPostReturnsBadResponse()
            {

            }

            // NEEDS WORK
            [Fact]
            public void PostSetsLocationHeader()
            {
                // Arrange

                var controller = SetupControllerWithEmptyRepoMocks();
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                string locationUrl = "https://localhost:44311/Sso/Login";

                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act
                var response = controller.Login() as HttpResponseMessage;
                _output.WriteLine(response.ToString());

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
                var controller = SetupControllerWithEmptyRepoMocks();

                // Act

                // Assert

            }

            // Do their login credentials make it to the controller (model binding validated)?

            // Malformed POST body

            // Model data is not mappable 

            // Do I send a successful response back?

            // Calls the JWT Manager to validate the token




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

        // TODO: @Scott Test the get methods for SSO Login
        public class GetLogin
        {

        }

        // TODO: @Scott Test the post methods for SSO Reset Password
        public class PostResetPassword
        {

        }

        
    }
}
