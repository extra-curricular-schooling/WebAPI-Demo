using ECS.DTO;
using ECS.WebAPI.Services;
using System.Net;
using System.Web.Http;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("registration")]
    public class RegistrationController : ApiController
    {
        /// <summary>
        /// Method accepts request to submit form using the POST method over HTTP
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        [Route("RegisterUser")]
        public IHttpActionResult RegisterUser()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var userAccount = JsonConverterService.DeserializeObject<AccountRegistrationDTO>(json);

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
            // Return successful response
            // return View(userAccount);
            return new HttpWebResponse(Ok);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        private void PostRegistrationToSSO(string username)
        {
            using(HttpClientService client = HttpClientService.Instance)
            {
                // Fix this up with a proper url.
                client.PostAsJson("*****", JsonConverterService.SerializeObject(username));
            }
        }

        /// <summary>
        /// Method accepts request to fetch security questions using the GET method over HTTP
        /// </summary>
        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult RequestSecurityQuestions()
        //{
        //}
    }
}