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
        /// <remarks>Author: Scott Roberts</remarks>
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

            using (RegistrationController regController = new RegistrationController())
            {
                Account account = new Account();
                User user = new User();
                string salt = HashService.CreateSaltKey();

                user.FirstName = registrationForm.FirstName;
                user.LastName = registrationForm.LastName;
                account.UserName = registrationForm.Username;
                user.Email = registrationForm.Email;
                account.Password = HashService.HashPasswordWithSalt(salt, registrationForm.Password);
                user.ZipLocation = new List<ZipLocation>
                {
                    new ZipLocation
                    {
                        ZipCode = Convert.ToString(registrationForm.ZipCode),
                        Address = registrationForm.Address,
                        City = registrationForm.City
                    }
                };
                account.SecurityAnswers = new List<SecurityQuestionAccount>
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

                regController.accountRepository.Insert(account);
                regController.userRepository.Insert(user);
                // context.Accounts.Add(account);
                // context.Users.Add(user);
                // context.SaveChanges();
                // return Content(HttpStatusCode.OK, new JavaScriptSerializer().Serialize(regController));
                return Ok();
            }

            // return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        private IHttpActionResult PostRegistrationToSSO(string username)
        {
            using (HttpClientService client = HttpClientService.SsoInstance)
            {
                // Fix this up with a proper url.
                var taskURL = client.PostAsJsonAsync("*****", JsonConverterService.SerializeObject(username));
            }

            // Change if needed.
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
                new SecurityQuestion{SecurityQuestionID = 1, SecurityQuestions = "Who?" },
                new SecurityQuestion{SecurityQuestionID = 2, SecurityQuestions = "What?" },
                new SecurityQuestion{SecurityQuestionID = 3, SecurityQuestions = "When?" },
                new SecurityQuestion{SecurityQuestionID = 4, SecurityQuestions = "Why?" }
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