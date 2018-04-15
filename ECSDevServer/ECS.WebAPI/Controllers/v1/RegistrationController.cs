using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.Hash;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Registration")]
    public class RegistrationController : ApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityQuestionRepository _securityQuestionRepository;
        private readonly ISaltRepository _saltRepository;

        public RegistrationController()
        {
            _accountRepository = new AccountRepository();
            _userRepository = new UserRepository();
            _securityQuestionRepository = new SecurityQuestionRepository();
            _saltRepository = new SaltRepository();
        }

        public RegistrationController(IAccountRepository accountRepo, IUserRepository userRepo, ISecurityQuestionRepository securityQuestionRepo, ISaltRepository saltRepo)
        {
            _accountRepository = accountRepo;
            _userRepository = userRepo;
            _securityQuestionRepository = securityQuestionRepo;
            _saltRepository = saltRepo;
        }

        /// <summary>
        /// Method accepts request to submit form using the POST method over HTTP
        /// </summary>
        [HttpPost]
        [Route("SubmitRegistration")]
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

            // Check if user already exists
            if (_accountRepository.Exists(d => d.UserName == registrationForm.Username))
            {
                string summary = "Username Exists";
                var error = new
                {
                    summary
                };

                return Content(HttpStatusCode.BadRequest, new JavaScriptSerializer().Serialize(error));
            }

            // Create Salt
            var mySalt = HashService.Instance.CreateSaltKey();

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

            var hashedAnswer1 = HashService.Instance.HashPasswordWithSalt(mySalt, registrationForm.SecurityQuestions[0].Answer, true);
            var hashedAnswer2 = HashService.Instance.HashPasswordWithSalt(mySalt, registrationForm.SecurityQuestions[1].Answer, true);
            var hashedAnswer3 = HashService.Instance.HashPasswordWithSalt(mySalt, registrationForm.SecurityQuestions[2].Answer, true);

            List<SecurityQuestionAccount> securityQuestionAccountListObj = new List<SecurityQuestionAccount>
            {
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer1,
                    SecurityQuestionID = registrationForm.SecurityQuestions[0].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer2,
                    SecurityQuestionID = registrationForm.SecurityQuestions[1].Question,
                    Username = registrationForm.Username
                },
                new SecurityQuestionAccount
                {
                    Answer = hashedAnswer3,
                    SecurityQuestionID = registrationForm.SecurityQuestions[2].Question,
                    Username = registrationForm.Username
                }
            };

            // DTO to Model
            UserProfile user = new UserProfile()
            {
                Email = registrationForm.Email,
                FirstName = registrationForm.FirstName,
                LastName = registrationForm.LastName,
                ZipLocations = zipLocationListObj
            };

            var hashedPassword = HashService.Instance.HashPasswordWithSalt(mySalt, registrationForm.Password, true);

            Account account = new Account()
            {
                UserName = registrationForm.Username,
                Email = registrationForm.Email,
                Password = hashedPassword,
                Points = 0,
                AccountStatus = true,
                SuspensionTime = DateTime.UtcNow,  // TODO: @Trish
                FirstTimeUser = true,
                SecurityAnswers = securityQuestionAccountListObj
            };

            Salt salt = new Salt()
            {
                PasswordSalt = mySalt,
                UserName = registrationForm.Username,
            };

            try
            {
                _userRepository.Insert(user);
                _accountRepository.Insert(account);
                _saltRepository.Insert(salt);

                return Ok();

            } catch (Exception ex)
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

                return Content(HttpStatusCode.InternalServerError, error);
            }
        }

        /// <summary>
        /// Method accepts request to submit incomplete form using the POST method over HTTP
        /// </summary>
        [HttpPost]
        [Route("FinishRegistration")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult FinishRegistration(RegistrationDTO registrationForm)
        {
            return Ok();
        }

        /// <summary>
        /// Method accepts request to fetch security questions using the GET method over HTTP
        /// </summary>
        [HttpGet]
        [Route("GetSecurityQuestions")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
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
