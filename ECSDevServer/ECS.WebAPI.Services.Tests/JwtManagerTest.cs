using System;
using Xunit;
using Moq;
using ECS.WebAPI.Services;
using Xunit.Abstractions;

namespace ECS.WebAPI.Services.Tests
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
            [Fact]
            public void FailShouldNotBeTheSameToken()
            {
                string token1 = JwtManager.GenerateToken("scott");
                System.Threading.Thread.Sleep(1000);
                string token2 = JwtManager.GenerateToken("scott");
                Assert.NotEqual(token1, token2);
            }
        }
    }
}
