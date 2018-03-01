using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECS.WebAPI
{
    public static class WebApiConfig
    {
        // Web API configuration and services
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS with default pipeline
            config.EnableCors();
            
            //config.MessageHandlers.Add(new PreflightRequestsHandler());

            // Setting up JSON serialization
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping(
                "Accept", 
                "text/html", 
                StringComparison.InvariantCultureIgnoreCase, 
                true, 
                "application/json"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Default Route to index.html
            config.Routes.MapHttpRoute(
                name: "Index",
                routeTemplate: "{id}.html",
                defaults: new { id = "index" });

            // Default Controller Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
