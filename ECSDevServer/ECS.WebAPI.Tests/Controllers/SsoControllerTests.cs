using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ECS.WebAPI.Tests.Controllers
{
    public class SsoControllerTests
    {
        public class Login
        {


            // Is the route acceptable
            [Theory]
            [InlineData("https://localhost:44311/Sso/Login")]
            public void RouteIsRecognized(string url)
            {

            }

                // Route "items" are spelled differently
            [Theory]
            [InlineData("https://localhost:44311/SSO/Login")]
            public void RouteIsNotRecognized(string url)
            {

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
        public class ResetPassword
        {

        }
    }
}
