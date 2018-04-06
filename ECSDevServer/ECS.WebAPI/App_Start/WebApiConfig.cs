using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using ECS.WebAPI.Filters.ExceptionFilters;
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

            // Non-default Controller Routes
            config.Routes.MapHttpRoute(
                name: "Sso",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { controller = "Sso" },
                handler:
                HttpClientFactory.CreatePipeline(
                    new HttpControllerDispatcher(config),
                    new DelegatingHandler[] { new SsoAccessTokenAuthenticationDelegatingHandler() })
            );

            // Default Controller Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" },
                constraints: null
                //handler:
                //HttpClientFactory.CreatePipeline(
                //    new HttpControllerDispatcher(config),
                //    new DelegatingHandler[] { new AccessTokenAuthenticationDelegatingHandler() })
            );

            // Authorization Filters

            // Action Filters

            // Exception Filters
            config.Filters.Add(new NotImplExceptionFilterAttribute());
            config.Filters.Add(new SqlExceptionFilterAttribute());

            config.Filters.Add(new AnyExceptionFilterAttribute()); // This should be last.
        }
    }
}
