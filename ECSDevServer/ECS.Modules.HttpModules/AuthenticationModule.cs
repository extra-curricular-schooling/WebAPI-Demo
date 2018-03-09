using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECS.Modules.HttpModules
{
    class AuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnHttpRequest);
        }

        // List of accepted referrer header values.
        List<string> acceptedReferrerUrls = new List<string>
        {
            "http://localhost:8080/",
            "https://www.ecschooling.org/",
            "https://ecschooling.org/"
        };

        // List of accepted orgin header values
        List<string> acceptedOrigins = new List<string>
        {
            "http://localhost:8080",
            "https://www.ecschooling.org",
            "https://ecschooling.org"
        };

        private void OnHttpRequest(object sender, EventArgs e)
        {
            // Cast the sender as an HttpApplication
            var app = sender as HttpApplication;
            var request = app.Request;
            if (request.GetType().Name.Equals("HttpRequest"))
            {
                if (request.HttpMethod.Equals("OPTIONS"))
                {
                    OnPreflightRequest(sender, e);
                }
                else
                {
                    if (request.Headers["Referer"] == null || !acceptedReferrerUrls.Contains(request.Headers["Referer"]))
                    {
                        app.Response.StatusCode = 401;
                        app.Response.End();
                    }
                }
            }
        }

        private void OnPreflightRequest(object sender, EventArgs e)
        {
            // Cast the sender as an HttpApplication
            var app = sender as HttpApplication;

            // All requests need to have a origin header and be on the whitelist.
            if (app.Request.Headers["Origin"] == null || !acceptedOrigins.Contains(app.Request.Headers["Origin"]))
            {
                app.Response.StatusCode = 401;
                app.Response.End();
            }

            if (app.Request.HttpMethod == "OPTIONS")
            {
                app.Response.StatusCode = 200;
                // Change for production... String concat is costly.
                app.Response.AddHeader("Access-Control-Allow-Headers",
                    "Access-Control-Allow-Origin," +
                    "Access-Control-Allow-Credentials," +
                    "origin," +
                    "accept," +
                    "content-type," +
                    "referer," +
                    "X-Requested-With");
                app.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
                app.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                app.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                app.Response.AddHeader("Content-Type", "application/json");
                app.Response.End();
            }
        }

    }
}
