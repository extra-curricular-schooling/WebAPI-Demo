using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using ECS.WebAPI.HttpMessageHandlers;

namespace ECS.WebAPI
{
    public static class WebApiConfig
    {
        // Web API configuration and services
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS with default pipeline
            config.EnableCors();

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

            config.Routes.MapHttpRoute(
                name: "Sso",
                routeTemplate: "Sso/{action}/{id}",
                defaults: new {id = RouteParameter.Optional, action = "Registration"},
                constraints: null,
                handler: new AccessTokenAuthenticationMessageHandler()
            );

            // Default Controller Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" }
            );
        }
    }
}
