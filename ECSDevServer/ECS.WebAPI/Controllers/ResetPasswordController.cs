using System.Net;
using System.Web.Http;
using ECS.DTO;
using ECS.Models;
using ECS.WebAPI.Services;

namespace ECS.WebAPI.Controllers
{
    [RoutePrefix("ResetPassword")]
    public class ResetPasswordController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        // The DTO we are using worries me because it will have an empty password field for this action
        // Should I make a AccountUsernameDTO???
        public IHttpActionResult Username([FromBody] AccountCredentialsDTO credentials)
        {
            // Credentials is already read and deserialized into a DTO. Validate it.
            Validate(credentials);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proccess any other information.

            // Check DB for username

            // Send User's security questions.
            using (HttpClientService client = HttpClientService.Instance)
            {
                // send to client.
            }

            // Return successful response
            return Ok();
        }
        [HttpGet]
        public AccountCredentialsDTO Username()
        {
            return new AccountCredentialsDTO();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        public IHttpActionResult SecurityAnswers([FromBody] AccountQuestionsDTO securityQuestions)
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
        public IHttpActionResult AccountPassword([FromBody] AccountCredentialsDTO credentials)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        /// <remarks>Author: Scott Roberts</remarks>
        private void PostNewPasswordToSSO(AccountCredentialsDTO credentials)
        {
            // Call request service to make a request to the SSO.
            using (var client = HttpClientService.Instance)
            {
                // The request should talk to the SSO controller to talk to the database.
                // The request should handle all successes and errors, or pass it off.

            }

            // We then need to save the User to our database.
            //using(var context = new ECSContext())

            // The return should be a Json object to the SSO server.

            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }



    }
}