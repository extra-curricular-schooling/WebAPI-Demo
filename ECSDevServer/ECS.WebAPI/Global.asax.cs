using ecs_dev_server;
using System.Web.Http;

namespace ECS.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AuthConfig.RegisterAuth();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // We have to configure the serializer to detect then handle self-referencing loops. 
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
        }
    }
}
