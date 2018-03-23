using Xunit;
using Moq;

namespace ECS.Security.Tests.Hash
{
    public class HashServiceUnitTests
    {
        public class CreateSaltKey
        {
            [Fact]
            public void KeyIsCorrectSize()
            {

            }
            // Add more...
        }

        public class HashPasswordWithSalt
        {
            [Fact]
            public void AddsPrependedSaltToPassword()
            {
                //const string salt = "aaa";
                //const string password = "pass";
                //const bool isPrependSalt = true;

            }

            [Fact]
            public void AddsAppendedSaltToPassword()
            {

            }

            [Fact]
            public void ReturnsPasswordCorrectLength()
            {

            }

            // Add more...
        }
    }
}
