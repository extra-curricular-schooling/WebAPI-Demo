using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using ECS.DTO;
using ECS.Models;
using ECS.Models.ECSContext;
using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http;
using ECS.Repositories;

namespace ECS.WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;

        public RegistrationController()
        {
            accountRepository = new AccountRepository();
            userRepository = new UserRepository();
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
            userRepository.Insert(user);

            Account account = new Account()
            {
                UserName = registrationForm.Username,
                Password = registrationForm.Password,
                AccountStatus = true,
                FirstTimeUser = true,
                SecurityAnswers = securityQuestionAccountListObj
            };
            accountRepository.Insert(account);

            return Ok();
        }

        /// <summary>
        /// Method accepts request to fetch security questions using the GET method over HTTP
        /// </summary>
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult GetSecurityQuestions()
        {

            // Insert the model into Ok() for it to return in the body as a JSON.

            // TEST ????
            List<SecurityQuestion> test = new List<SecurityQuestion> {
                new SecurityQuestion{SecurityQuestionID = 1, SecQuestion = "Who?" },
                new SecurityQuestion{SecurityQuestionID = 2, SecQuestion = "What?" },
                new SecurityQuestion{SecurityQuestionID = 3, SecQuestion = "When?" },
                new SecurityQuestion{SecurityQuestionID = 4, SecQuestion = "Why?" }
            };
            
            return Content(HttpStatusCode.OK, new JavaScriptSerializer().Serialize(test));
        }
    }
}

// Proccess any other information.
//if (ModelState.IsValid)
//{
//    // Check SSO DB for User.
//    //PostRegistrationToSSO(userAccount.Username);

//    // If successful, save user to app DB. If not successful, reject registration.
//    using (ECS.ECSContext.ECSContext context = new ECS.ECSContext.ECSContext())
//    {
//        context.Accounts.Add(new Account
//        {
//            UserName = userAccount.Username,
//            Password = HashService.HashPasswordWithSalt(userAccount.Password, HashService.CreateSaltKey()), //ConfirmPassword = userAccount.ConfirmPassword
//            SecurityAnswers = new List<SecurityQuestionAccount>
//            {
//                new SecurityQuestionAccount
//                {
//                    Answer = userAccount.SecurityAnswers.ElementAt(0),
//                    SecurityQuestionID = userAccount.SecurityQuestions.ElementAt(0)
//                },
//                new SecurityQuestionAccount
//                {
//                    Answer = userAccount.SecurityAnswers.ElementAt(1),
//                    SecurityQuestion = userAccount.SecurityQuestions.ElementAt(1)
//                },
//                new SecurityQuestionAccount
//                {
//                    Answer = userAccount.SecurityAnswers.ElementAt(2),
//                    SecurityQuestion = userAccount.SecurityQuestions.ElementAt(2)
//                }
//            }
//        });
//        context.Users.Add(new User
//        {
//            Email = userAccount.Email,
//            FirstName = userAccount.FirstName,
//            LastName = userAccount.LastName,
//            Address = userAccount.Address
//        });
//        context.ZipLocations.Add(new ZipLocation
//        {
//            ZipCode = userAccount.ZipCode,
//            City = userAccount.City,
//            State = userAccount.State
//        });
//    }
//    context.SaveChanges();
//    // return RedirectToAction();
//}