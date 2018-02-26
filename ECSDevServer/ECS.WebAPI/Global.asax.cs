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
        }
    }
}
