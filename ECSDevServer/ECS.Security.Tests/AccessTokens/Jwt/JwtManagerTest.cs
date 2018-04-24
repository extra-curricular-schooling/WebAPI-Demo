using System.Threading;
using ECS.DTO.Sso;
using ECS.Security.AccessTokens.Jwt;
using Xunit;
using Xunit.Abstractions;

namespace ECS.Security.Tests.AccessTokens.Jwt
{
    public class JwtManagerTest
    {
        private readonly ITestOutputHelper output;

        public JwtManagerTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        public class GenerateTokenTest
        {
            private readonly ITestOutputHelper output;

            public GenerateTokenTest(ITestOutputHelper output)
            {
                this.output = output;
            }

            [Fact]
            public void ShouldBeSameToken()
            {
                string token1 = JwtManager.Instance.GenerateToken("scott");
                output.WriteLine(token1);
                string token2 = JwtManager.Instance.GenerateToken("scott");
                output.WriteLine(token2);
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
                string token1 = JwtManager.Instance.GenerateToken("scott");
                Thread.Sleep(ms);
                string token2 = JwtManager.Instance.GenerateToken("scott");
                Assert.NotEqual(token1, token2);
            }

            [Theory]
            [InlineData("a", "Scholar", "a")]
            public void PrintSsoToken(string password, string roleType, string username)
            {
                SsoLoginRequestDTO loginDto = new SsoLoginRequestDTO
                {
                    Password = password,
                    RoleType = roleType,
                    Username = username
                };
                output.WriteLine(SsoJwtManager.Instance.GenerateToken(loginDto));
            }
        }
    }
}
