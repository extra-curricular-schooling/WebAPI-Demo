using System.Collections.Generic;
using System.Web.Script.Serialization;
using ECS.DTO;
using ECS.Models;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Repositories;
using System;

namespace ECS.WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityQuestionRepository _securityQuestionRepository;

        public RegistrationController()
        {
            _accountRepository = new AccountRepository();
            _userRepository = new UserRepository();
            _securityQuestionRepository = new SecurityQuestionRepository();
        }

        public RegistrationController(IAccountRepository accountRepo, IUserRepository userRepo, ISecurityQuestionRepository securityQuestionRepo)
        {
            _accountRepository = accountRepo;
            _userRepository = userRepo;
            _securityQuestionRepository = securityQuestionRepo;
        }

        /// <summary>
        /// Method accepts request to submit form using the POST method over HTTP
        /// </summary>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
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

            // Temporary Objects
            List<ZipLocation> zipLocationListObj = new List<ZipLocation>
            {
                new ZipLocation
                {
                    ZipCode = registrationForm.ZipCode.ToString(),
                    Address = registrationForm.Address,
                    City = registrationForm.City,
                    State = registrationForm.State
                }
            };

            List<SecurityQuestionAccount> securityQuestionAccountListObj = new List<SecurityQuestionAccount>
            {
                new SecurityQuestionAccount
                {
                    Answer = registrationForm.SecurityQuestions[0].Answer,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question
                },
                new SecurityQuestionAccount
                {
                    Answer = registrationForm.SecurityQuestions[1].Answer,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question
                },
                new SecurityQuestionAccount
                {
                    Answer = registrationForm.SecurityQuestions[2].Answer,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question
                }
            };

            // DTO to Model
            User user = new User()
            {
                Email = registrationForm.Email,
                FirstName = registrationForm.FirstName,
                LastName = registrationForm.LastName,
                ZipLocations = zipLocationListObj
            };
            _userRepository.Insert(user);

            Account account = new Account()
            {
                UserName = registrationForm.Username,
                Email = registrationForm.Email,
                Password = registrationForm.Password,
                AccountStatus = true,
                SuspensionTime = DateTime.UtcNow,
                FirstTimeUser = true,
                SecurityAnswers = securityQuestionAccountListObj
            };
            _accountRepository.Insert(account);

            return Ok();
        }

        /// <summary>
        /// Method accepts request to fetch security questions using the GET method over HTTP
        /// </summary>
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult GetSecurityQuestions()
        {
            List<SecurityQuestion> allQuestions;
            allQuestions = (List<SecurityQuestion>) _securityQuestionRepository.GetAll();

            // TODO: @Trish change to Ok()
            return Content(HttpStatusCode.OK, new JavaScriptSerializer().Serialize(allQuestions));
        }
    }
}
