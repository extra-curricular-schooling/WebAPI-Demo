using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.Constants.Network;
using ECS.WebAPI.Filters.ExceptionFilters;
using ECS.WebAPI.Transformers;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sso")]
    [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET,POST")]
    [UnauthorizedAccessExceptionFilter]
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

         /// <summary>
         /// Sso Registration Endpoint
         /// </summary>
         /// <returns>Appropriate response message</returns>
         [HttpPost]
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

        /// <summary>
        /// Sso ResetPassword Endpoint
        /// </summary>
        /// <returns>Appropriate response message</returns>
        [HttpPost]
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