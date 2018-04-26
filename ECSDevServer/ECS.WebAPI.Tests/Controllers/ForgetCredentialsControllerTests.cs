using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECS.WebAPI.Tests.Controllers
{
    public class ForgetCredentialsControllerTests
    {
        // private readonly AccountLogic _accountLogic;
        // private readonly SecurityQuestionsAccountLogic _securityQuestionsAccountLogic;
        // private readonly SaltSecurityAnswerLogic _saltSecurityAnswerLogic;
        // private readonly SaltLogic _saltLogic;

        public class GetUsername
        {
            [Fact]
            public void GetReturnsOkResponse()
            {
                
            }

            [Fact]
            public void GetReturnsConflictResponse()
            {

            }

            [Fact]
            public void GetReturnsInternalServerErrorResponse()
            {

            }
        }

        public class GetSecurityQuestions
        {
            [Fact]
            public void GetReturnsOkResponse()
            {

            }

            [Fact]
            public void GetReturnsConflictResponse()
            {

            }
        }

        public class SubmitAnswers
        {
            [Fact]
            public void GetReturnsOkResponse()
            {

            }

            [Fact]
            public void GetReturnsForbiddenResponse()
            {

            }
        }

        public class SubmitNewPassword
        {
            [Fact]
            public void GetReturnsOkResponse()
            {

            }

            [Fact]
            public void GetReturnsInternalServerErrorResponse()
            {

            }
        }
    }
}
