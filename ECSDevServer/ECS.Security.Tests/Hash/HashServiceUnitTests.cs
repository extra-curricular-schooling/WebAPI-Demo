using ECS.Security.Hash;
using Xunit;
using Moq;
using Xunit.Abstractions;

namespace ECS.Security.Tests.Hash
{
    public class HashServiceUnitTests
    {
        public class CreateSaltKey
        {
            private readonly ITestOutputHelper _output;

            public CreateSaltKey(ITestOutputHelper output)
            {
                _output = output;
            }

            [Fact]
            public void KeyIsCorrectSize()
            {
                _output.WriteLine(HashService.Instance.CreateSaltKey());
            }
            // Add more...
        }

        public class HashPasswordWithSalt
        {
            private readonly ITestOutputHelper _output;

            public HashPasswordWithSalt(ITestOutputHelper output)
            {
                _output = output;
            }

            [Fact]
            public void AddsPrependedSaltToPassword()
            {
                var salt = HashService.Instance.CreateSaltKey();
                _output.WriteLine("Salt: " + salt);

                const string password = "aaaaaaaaa";
                const bool isPrependSalt = true;

                var hashNSaltPassword = HashService.Instance.HashPasswordWithSalt(salt, password, isPrependSalt);
                _output.WriteLine("Hashed: " + hashNSaltPassword);
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
