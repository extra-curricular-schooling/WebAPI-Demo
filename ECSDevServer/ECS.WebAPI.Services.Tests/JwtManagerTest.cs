using System;
using Xunit;
using Moq;
using ECS.WebAPI.Services;
namespace ECS.WebAPI.Services.Tests
{
    public class JwtManagerTest
    {
        public class GenerateTokenWithoutSecretTest
        {
            [Fact]
            public void PassShouldBeTheSameToken()
            {
                string token1 = JwtManager.GenerateTokenWithoutSecret("scott");
                string token2 = JwtManager.GenerateTokenWithoutSecret("scott");
                Assert.Same(token1, token2);
            }
        }
        public class GenerateTokenTest
        {
            [Fact]
            public void FailShouldNotBeTheSameToken()
            {
                string token1 = JwtManager.GenerateToken("scott");
                string token2 = JwtManager.GenerateToken("scott");
                Assert.NotSame(token1, token2);
                
            }
        }
    }
}
