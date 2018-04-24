using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using ECS.DTO.Sso;
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

            [Theory]
            [InlineData("a", "Scholar", "a")]
            public void ShouldBeSameToken(string password, string roleType, string username)
            {
                SsoLoginRequestDTO loginDto = new SsoLoginRequestDTO
                {
                    Password = password,
                    RoleType = roleType,
                    Username = username
                };
                string token1 = SsoJwtManager.Instance.GenerateToken(loginDto);
                _output.WriteLine(token1);
                string token2 = SsoJwtManager.Instance.GenerateToken(loginDto);
                _output.WriteLine(token2);
                Assert.Equal(token1, token2);
            }

            // Tokens need a certain amount of time to be refreshed by the generator
            // 100 milliseconds is too little to have different tokens, hence the failed test.
            [Theory]
            [InlineData(100, "a", "Scholar", "a")]
            [InlineData(500, "a", "Scholar", "a")]
            [InlineData(1000, "a", "Scholar", "a")]
            public void ShouldNotBeTheSameToken(int ms, string password, string roleType, string username)
            {
                SsoLoginRequestDTO loginDto = new SsoLoginRequestDTO
                {
                    Password = password,
                    RoleType = roleType,
                    Username = username
                };
                string token1 = SsoJwtManager.Instance.GenerateToken(loginDto);
                Thread.Sleep(ms);
                string token2 = SsoJwtManager.Instance.GenerateToken(loginDto);
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
                _output.WriteLine(SsoJwtManager.Instance.GenerateToken(loginDto));
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
            
        }

        public class GetClaimValue
        {

        }
    }
}
