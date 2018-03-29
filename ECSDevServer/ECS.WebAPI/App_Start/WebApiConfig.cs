using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using ECS.WebAPI.Filters.ExceptionFilters;
using ECS.WebAPI.HttpMessageHandlers;
using ECS.WebAPI.HttpMessageHandlers.DelegatingHandlers;

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

            // Important that this route exists before the default.
            // If the route is specific, put it before the more general routes.

            //config.Routes.MapHttpRoute(
            //    name: "Sso",
            //    routeTemplate: "Sso/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: null,
            //    handler: 
            //    HttpClientFactory.CreatePipeline(
            //        new HttpControllerDispatcher(config), 
            //        new DelegatingHandler[]{new AccessTokenAuthenticationDelegatingHandler()})
            //);

            // TODO @Scott Change the authentication handler before committing. It will mess up everyone's authentication.

            // Default Controller Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" },
                constraints: null
                //handler: 
                //HttpClientFactory.CreatePipeline(
                //    new HttpControllerDispatcher(config), 
                //    new DelegatingHandler[]{new AccessTokenAuthenticationDelegatingHandler()})
            );

            // Exception Filters
            // config.Filters.Add(new AnyExceptionFilterAttribute());
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
