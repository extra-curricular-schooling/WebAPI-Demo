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



        [HttpPost]
        [Route("NewPassword")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult NewPassword(AccountCredentialDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (ModelState.IsValid)
            {
                // We need to take this information and update the user's password in the db.
                
                // Return 200
                return Ok("Post Reset Password");
            }

            // Fail state
            return BadRequest(ModelState);
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