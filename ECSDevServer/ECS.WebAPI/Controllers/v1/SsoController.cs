using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers;
using ECS.WebAPI.Transformers;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST")]
    //[AuthorizeSsoAccessToken]
    public class SsoController : ApiController
    {
        private readonly SsoControllerLogic _controllerLogic;

        public SsoController()
        {
            _controllerLogic = new SsoControllerLogic();
        }

        public SsoController(SsoControllerLogic controllerLogic)
        {
            _controllerLogic = controllerLogic;
        }

        /*
         * When Web API encounters a type implementing this interface as result of an 
         * executed action, instead of running content negotiation, it will call 
         * its only method (Execute) to produce the HttpResponseMessage, and then use that to 
         * respond to the client
         */
        [HttpPost]
        //[Route("Registration")]
         public IHttpActionResult Registration()
        {
            // Transform request context into DTO.
            var transformer = new SsoRegistrationTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // TODO: @Scott Validate / Sanitize Dto data.
            //var validator = new SsoValidator();
            //validator.Validate(ssoDto);

            var response = _controllerLogic.RegisterPartialAccount(ssoDto);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;

            // return transformer.Send(response);
        }

        /// <summary>
        /// TEST ACTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("LoginRedirect")]
        //public HttpResponseMessage LoginRedirect()
        //{
        //    var response = Request.CreateResponse();

        //    // Transform request context into DTO.
        //    var transformer = new SsoLoginTransformer();
        //    var ssoDto = transformer.Fetch(RequestContext);

        //    // Grab the accounts to check for username and password
        //    var account = _accountRepository.GetSingle(acc => acc.UserName == ssoDto.Username);
        //    var partialAccount = _partialAccountRepository.GetSingle(partial => partial.UserName == ssoDto.Username);


        //    // TODO: @Scott Sso Login needs to generate a token with a username AND list of claims. Get claims from account.
        //    // Generate our token for them.
        //    var token = JwtManager.Instance.GenerateToken(ssoDto.Username);

        //    // If the partial account exists, then the Account needs a full registration. Redirect them.
        //    if (partialAccount != null)
        //    {

        //        response.StatusCode = HttpStatusCode.MovedPermanently;
        //        response.Headers.Location = new Uri("http://localhost:8080/partial-registration");
        //        response.Headers.Add("Access-Control-Allow-Origin", Request.Headers.GetValues("Origin"));
        //        response.Headers.Add("Access-Control-Allow-Credentials", "true");
        //        response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");

        //    }

        //    return response;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [HttpPost]
        //[Route("Login")]
        public IHttpActionResult Login()
        {
            // Transform request context into DTO.
            var transformer = new SsoLoginTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

            // TODO: @Scott Validate / Sanitize Dto data.
            //var validator = new SsoValidator();
            //validator.Validate(ssoDto);

            var response = _controllerLogic.Login(ssoDto);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;

            // return transformer.Send(response);
        }

        [HttpPost]
        //[Route("ResetPassword")]
        public IHttpActionResult ResetPassword()
        {
            var transformer = new SsoResetPasswordTransformer();
            var ssoDto = transformer.Fetch(this.RequestContext);

            // TODO: @Scott Validate / Sanitize Dto data.
            
            //var validator = new SsoValidator();
            //validator.Validate(ssoDto);

            var response = _controllerLogic.ResetPassword(ssoDto);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;

            // return transformer.Send(response);
        }
    }
}