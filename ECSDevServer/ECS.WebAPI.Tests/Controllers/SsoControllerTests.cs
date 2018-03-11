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
            private IAccountRepository accountRepo;
            private string controllerName = "Sso";
            private string actionName = "Login";
            private readonly ITestOutputHelper output;

            public Login(ITestOutputHelper output)
            {
                this.output = output;
                accountRepo = new AccountRepository();
            }

            [Fact]
            public void PostSetsLocationHeader_MockVersion()
            {
                // This version uses a mock UrlHelper.

                // Arrange
                SsoController controller = new SsoController(accountRepo);
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                string locationUrl = "http://location/";

                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act
                AccountCredentialDTO credential = new AccountCredentialDTO()
                {
                    Username = "Scott",
                    Password = "pass"
                };

                var response = controller.Login();

                // Assert
                // Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);
            }

            // Is the route acceptable
            [Fact]
            public void RouteIsRecognized()
            {
                SsoController controller = new SsoController();
                SetupControllerWithoutIdIntegration(HttpMethod.Post, controller, controllerName, actionName);

                // Act
                // Make sure that you actually simulate calling a route... might be hard to test.

                output.WriteLine(controller.Request.ToString());
            }

            // Route "items" are spelled differently
            [Theory]
            [InlineData("SSO", "Login")]
            [InlineData("sso", "Login")]
            [InlineData("Sso", "login")]
            public void RouteIsNotRecognized(string controllerName, string actionName)
            {
                output.WriteLine(controllerName + "/" + actionName);
            }

            // Does the post work?
            [Fact]
            public void PostRegistrationReturnsCreatedStatusCode()
            {
                var repo = new AccountRepository();
                var controller = new SsoController(repo);
                SetupControllerWithoutIdIntegration(HttpMethod.Post, controller, controllerName, actionName);

                // Need the information from the JWT to work here.
                var result = controller.Login();

                output.WriteLine(result.ToString());

                Assert.IsType<OkResult>(result);
            }

            [Fact]
            public void ReturnsJwtTokenWithOk()
            {
                var mockRepo = new Mock<IJwtRepository>();
                //mockRepo.Setup(x => x.GetById()).Returns
            }

            // Check the anti-forgery token

            // Check if CORS is accepted

            // Different domain

            // Unacceptable Headers

            // Unacceptable HttpVerbs

            // Does this access point allow anonymous access (not logged in yet)

            // Allow Anonymous filter code....

            // Do their login credentials make it to the controller (model binding validated)?

            // Malformed POST body

            // Model data is not mappable 

            // Is the data being validated?

            // Non-null values

            // Do I need sanitization here?

            // Is the data access connection open?

            // Do the credentials get saved into the repository/gateway? (Data access response)

            // Do I send a successful response back?
        }
        public class Register
        {

        }
    }
}
