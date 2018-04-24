using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.DTO;
using ECS.Constants.Network;

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
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
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
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
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
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
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
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult SubmitNewPassword(AccountCredentialDTO credentials)
        {
            Validate(credentials);

            if (credentials.Username == null || credentials.Password == null)
                return BadRequest("Bad Request");

            var response = _controllerLogic.PasswordSubmission(credentials);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }
    }
}