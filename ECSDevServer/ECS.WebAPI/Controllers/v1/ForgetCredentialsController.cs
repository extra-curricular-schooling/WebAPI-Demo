using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.DTO;
using ECS.WebAPI.HttpClients;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/ForgetCredentials")]
    public class ForgetCredentialsController : ApiController
    {
        private readonly ForgetCredentialsControllerLogic _controllerLogic;

        public ForgetCredentialsController()
        {
            _controllerLogic = new ForgetCredentialsControllerLogic();
        }

        /// <summary>
        /// Method consumes email in query string and returns http response
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsername")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult GetUsername(string email)
        {
            if (email == null)
                return BadRequest("Bad Request");

            var response = _controllerLogic.EmailSubmission(email);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }
        
        /// <summary>
        /// Method consumes username in query string and returns http response
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSecurityQuestions")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult GetSecurityQuestions(string username)
        {
            if (username == null)
                return BadRequest("Bad Request");

            var response = _controllerLogic.UsernameSubmission(username);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
            
        }

        /// <summary>
        /// Method consumes posted data to verify answers to stored security questions
        /// and returns http response
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SubmitAnswers")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult SubmitAnswers(AccountPostAnswersDTO answers)
        {
            Validate(answers);

            if (answers.Username == null || answers.SecurityQuestions == null)
                return BadRequest("Bad Request");

            var response = _controllerLogic.AnswersSubmission(answers);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }

        /// <summary>
        /// Method consumes new password credentials to update user information
        /// and returns http response
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SubmitNewPassword")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult SubmitNewPassword(AccountCredentialDTO credentials)
        {
            Validate(credentials);

            if (credentials.Username == null || credentials.Password == null)
                return BadRequest("Bad Request");

            var response = _controllerLogic.PasswordSubmission(credentials);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        //[HttpPost]
        //[Route("Password")]
        //// The DTO we are using worries me because it will have an empty password field for this action
        //// Should I make a AccountUsernameDTO???
        //public IHttpActionResult Username(AccountCredentialDTO credentials)
        //{
        //    // Credentials is already read and deserialized into a DTO. Validate it.
        //    Validate(credentials);

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // Proccess any other information.

        //    // Check DB for username

        //    // Send User's security questions.
        //    using (HttpClientService client = HttpClientService.SsoInstance)
        //    {
        //        // send to client.
        //    }

        //    // Return successful response
        //    return Ok();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [Route("SecurityAnswers")]
        public IHttpActionResult SecurityAnswers(SecurityQuestionDTO securityQuestions)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(securityQuestions);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.

            // Verify User's answers.

            // Redirect User to Account reset password page??

            // Return successful response
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [Route("AccountPassword")]
        public IHttpActionResult AccountPassword(AccountCredentialDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.

            // Submit new password to app DB.

            // After you finish the resetpassword action, we need to send the finished information to the SSO.
            //PostNewPasswordToSSO(credentials);

            // Redirect User to Account reset password page??

            // Return successful response
            return Ok();
        }
    }
}