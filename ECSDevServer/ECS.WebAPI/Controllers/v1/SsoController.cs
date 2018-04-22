using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.Constants.Network;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.Security.AccessTokens.Jwt;
using ECS.Security.Hash;
using ECS.WebAPI.Services.Transformers;
using ECS.WebAPI.Transformers;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET,POST")]
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

            var response = _controllerLogic.RegisterPartialAccount(ssoDto);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;

            // return transformer.Send(response);
         }

        /// <summary>
        /// Sso Login Endpoint
        /// </summary>
        /// <returns>Appropriate response message</returns>
        [HttpPost]
        //[Route("Login")]
        public IHttpActionResult Login()
        {
            // Transform request context into DTO.
            var transformer = new SsoLoginTransformer();
            var ssoDto = transformer.Fetch(RequestContext);

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

            var response = _controllerLogic.ResetPassword(ssoDto);
            IHttpActionResult actionResultResponse = ResponseMessage(response);

            return actionResultResponse;
        }
    }
}