using System;
using Xunit;
using Moq;
using ECS.DTO;

namespace ECS.WebAPI.Tests
{
    public class RegistrationControllerTests
    {
        public class GetRegistration
        {

        }
        public class PostRegistration
        {
            [Fact]
            public void ReturnOkResponse()
            {
                // Arrange
                AccountRegistrationDTO account = new AccountRegistrationDTO
                {
                    Username = "Scott",
                    Password = "Hello",
                    FirstName = "Mine"
                };

                // Act
                

                // Assert
            }

        }
    }
}
