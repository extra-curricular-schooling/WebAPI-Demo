using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using ECS.Security.AccessTokens.Jwt;
using Xunit;
using Moq;
using Xunit.Abstractions;

namespace ECS.Security.Tests.AccessTokens.Jwt
{
    public class SsoJwtManagerTest
    {
        public class GenerateToken
        {
            private readonly ITestOutputHelper _output;

            public GenerateToken(ITestOutputHelper output)
            {
                _output = output;
            }

            [Fact]
            public void ShouldBeSameToken()
            {
                string token1 = SsoJwtManager.Instance.GenerateToken("scott");
                _output.WriteLine(token1);
                string token2 = SsoJwtManager.Instance.GenerateToken("scott");
                _output.WriteLine(token2);
                Assert.Equal(token1, token2);
            }

            // Tokens need a certain amount of time to be refreshed by the generator
            // 100 milliseconds is too little to have different tokens, hence the failed test.
            [Theory]
            [InlineData(100)]
            [InlineData(500)]
            [InlineData(1000)]
            public void ShouldNotBeTheSameToken(int ms)
            {
                string token1 = SsoJwtManager.Instance.GenerateToken("scott");
                Thread.Sleep(ms);
                string token2 = SsoJwtManager.Instance.GenerateToken("scott");
                Assert.NotEqual(token1, token2);
            }

            [Fact]
            public void PrintSsoToken()
            {
                _output.WriteLine(SsoJwtManager.Instance.GenerateToken("test5", 100));
            }
        }

        public class GenerateTokenTest
        {
            private readonly ITestOutputHelper _output;

            public GenerateTokenTest(ITestOutputHelper output)
            {
                _output = output;
            }

            [Fact]
            public void ShouldBeSameToken()
            {
                SortedList claims = new SortedList
                {
                    {"scott", "roberts"},
                    {"bob", "sagget"}
                };

                string token1 = SsoJwtManager.Instance.GenerateTokenTest("scott");
                _output.WriteLine(token1);
                string token2 = SsoJwtManager.Instance.GenerateTokenTest("scott");
                _output.WriteLine(token2);
                Assert.Equal(token1, token2);
            }

            // Tokens need a certain amount of time to be refreshed by the generator
            // 100 milliseconds is too little to have different tokens, hence the failed test.
            [Theory]
            [InlineData(100)]
            [InlineData(500)]
            [InlineData(1000)]
            public void ShouldNotBeTheSameToken(int ms)
            {
                string token1 = SsoJwtManager.Instance.GenerateTokenTest("scott");
                Thread.Sleep(ms);
                string token2 = SsoJwtManager.Instance.GenerateTokenTest("scott");
                Assert.NotEqual(token1, token2);
            }

            [Fact]
            public void PrintSsoToken()
            {
                _output.WriteLine(SsoJwtManager.Instance.GenerateTokenTest("test5", 100));
            }
        }

        public class GetPrincipal
        {

        }

        public class ValidateToken
        {

        }

        public class AuthenticateJwtToken
        {

        }

        public class GetJwtsFromHeaders
        {
            // Make sure you Mock the incoming HttpRequestMessage
        }

        public class GetJwtFromAuthorizationHeader
        {
            // Mock the HttpRequestMessage
        }

        public class GetClaim
        {
            // TODO: @Scott Uncomment this test case.

            //[Theory]
            //[InlineData("username")]
            //public void ReturnsCorrectClaim(string claimType)
            //{
            //    Assert.True(true);
            //}
        }

        public class GetClaimValue
        {

        }
    }
}
