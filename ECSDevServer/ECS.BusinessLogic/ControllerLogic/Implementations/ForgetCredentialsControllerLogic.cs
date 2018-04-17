using ECS.BusinessLogic.ModelLogic.Implementations;
using ECS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BusinessLogic.ControllerLogic.Implementations
{
    public class ForgetCredentialsControllerLogic
    {
        private readonly AccountLogic _accountLogic;

        public ForgetCredentialsControllerLogic()
        {
            _accountLogic = new AccountLogic();
        }

        public ForgetCredentialsControllerLogic(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public HttpResponseMessage EmailSubmission(string email)
        {
            // Check if email doesn't exist
            if (!_accountLogic.EmailExists(email))
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "No Email Found",
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            var accountModel = _accountLogic.GetByEmail(email);
            var username = new StringContent(accountModel.UserName);

            return new HttpResponseMessage
            {
                Content = username,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
