using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.Constants.Network;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.Hash;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Registration")]
    public class RegistrationController : ApiController
    {
        // TODO: @Scott Try to make the controller logic follow interfaces (like a transformer: fetch and send)
        private readonly RegistrationControllerLogic _controllerLogic;

        private readonly ISecurityQuestionRepository _securityQuestionRepository;

        public RegistrationController()
        {
            _controllerLogic = new RegistrationControllerLogic();
            _securityQuestionRepository = new SecurityQuestionRepository();
        }

        public RegistrationController(ISecurityQuestionRepository securityQuestionRepo, RegistrationControllerLogic controllerLogic)
        {
            _securityQuestionRepository = securityQuestionRepo;
            _controllerLogic = controllerLogic;
        }

        /// <summary>
        /// Method accepts request to submit form using the POST method over HTTP
        /// </summary>
        [HttpPost]
        [Route("SubmitRegistration")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult SubmitRegistration(RegistrationDTO registrationForm)
        {
            Validate(registrationForm);

            // return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Make custom error validator to make sure all values are not null... This is only the start.
            if (registrationForm.FirstName == null || 
                registrationForm.LastName == null ||
                registrationForm.Username == null ||
                registrationForm.Email == null ||
                registrationForm.Password == null ||
                registrationForm.SecurityQuestions[0].Answer == null ||
                registrationForm.SecurityQuestions[1].Answer == null ||
                registrationForm.SecurityQuestions[2].Answer == null)
                return BadRequest("Improper Request");

            var response = _controllerLogic.Registration(registrationForm);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }

        /// <summary>
        /// Method accepts request to submit incomplete form using the POST method over HTTP
        /// </summary>
        [HttpPost]
        [Route("SubmitPartialRegistration")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult SubmitPartialRegistration(RegistrationDTO registrationForm)
        {
            Validate(registrationForm);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Make custom error validator to make sure all values are not null... This is only the start.

            // The only difference is the password.
            if (registrationForm.FirstName == null || 
                registrationForm.LastName == null ||
                registrationForm.Username == null ||
                registrationForm.Password != null ||
                registrationForm.Email == null ||
                registrationForm.SecurityQuestions[0].Answer == null ||
                registrationForm.SecurityQuestions[1].Answer == null ||
                registrationForm.SecurityQuestions[2].Answer == null)
                return BadRequest("Improper Request");

            var response = _controllerLogic.FinishRegistration(registrationForm);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }


        /// <summary>
        /// Method accepts request to fetch security questions using the GET method over HTTP
        /// </summary>
        [HttpGet]
        [Route("GetSecurityQuestions")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        [AllowAnonymous]
        public IHttpActionResult GetSecurityQuestions()
        {
            try
            {
                List<SecurityQuestion> allQuestions;
                allQuestions = (List<SecurityQuestion>) _securityQuestionRepository.GetAll();

                if (allQuestions.Count == 0)
                {
                    string summary = "No Content";

                    var error = new
                    {
                        summary
                    };

                    return Content(HttpStatusCode.ServiceUnavailable, new JavaScriptSerializer().Serialize(error));
                }
                return Content(HttpStatusCode.OK, new JavaScriptSerializer().Serialize(allQuestions));
            }
            catch (Exception ex)
            {
                string summary = "Data Access Error";
                string source = ex.Source;
                string message = ex.Message;
                string stackTrace = ex.StackTrace;

                var error = new
                {
                    summary,
                    source,
                    message,
                    stackTrace
                };

                return Content(HttpStatusCode.InternalServerError, new JavaScriptSerializer().Serialize(error));
            }
        }
    }
}
