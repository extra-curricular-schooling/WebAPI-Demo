using ECS.WebAPI.ExceptionHandlers;
using ecs_dev_server;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ECS.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Begin_Request()
        {
            // Set the Cors to always be the correct origin.
        }
        protected void Application_Start()
        {
            // Logging for any 
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger());
            AuthConfig.RegisterAuth();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // We have to configure the serializer to detect then handle self-referencing loops. 
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;

        }
    }
}
