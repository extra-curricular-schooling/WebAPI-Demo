using ECS.DTO;
using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECS.WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {

        /// <summary>
        /// Method accepts request to submit form using the POST method over HTTP
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult SubmitRegistration(RegistrationDTO registrationForm)
        {
            Validate(registrationForm);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Make custom error validator to make sure all values are not null... This is only the start.
            if (registrationForm.Username == null || registrationForm.Password == null)
                return BadRequest("Improper Request");



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

            return Ok();
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
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult SecurityQuestions()
        {

            // Insert the model into Ok() for it to return in the body as a JSON.
            return Ok();
        }
    }
}