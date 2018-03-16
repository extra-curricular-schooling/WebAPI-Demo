using System;
using System.Collections.Generic;
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
        HashSet<string> acceptedUrls = new HashSet<string>
        {
            "https://localhost:44311/",
            "http://localhost:8080/",
            "https://www.ecschooling.org/",
            "https://ecschooling.org/"
        };

        HashSet<string> acceptedAuthorities = new HashSet<string>
        {
            "localhost:44311"
        };

        // List of accepted orgin header values
        HashSet<string> acceptedOrigins = new HashSet<string>
        {
            "http://localhost:8080",
            "https://www.ecschooling.org",
            "https://ecschooling.org"
        };

        private void OnHttpRequest(object sender, EventArgs e)
        {
            // Cast the sender as an HttpApplication
            var app = sender as HttpApplication;

            if(app.Request.GetType().Name.Equals("HttpRequest"))
            {
                var request = app.Request;
                var type = request.GetType();
               
                bool isAcceptedRefererHeader = CheckRefererHeader(request);
                bool isAcceptedOriginHeader = CheckOriginHeader(request);
                bool isAcceptedUrlAuthorityHeader = CheckUrlAuthority(request);

                // Return the bad request
                if (!isAcceptedRefererHeader && !isAcceptedOriginHeader && !isAcceptedUrlAuthorityHeader)
                {
                    // Http Status Code 403: Request is correct, but our API refuses to serve for this request.
                    app.Response.StatusCode = 403;
                    app.Response.End();
                }

                // All requests from this point on are from valid sources.
                // If you want to shortcut something, put it in after this point!

                // For Preflight
                if (app.Request.HttpMethod == "OPTIONS")
                {
                    app.Response.StatusCode = 200;
                    // Change for production... String concat is costly.
                    app.Response.AddHeader("Access-Control-Allow-Headers",
                        "Access-Control-Allow-Origin," +
                        "Access-Control-Allow-Credentials," +
                        "Authorization," +
                        "origin," +
                        "accept," +
                        "content-type," +
                        "referer," +
                        "X-Requested-With");
                    app.Response.AddHeader("Access-Control-Allow-Origin", request.Headers["Origin"]);
                    app.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                    app.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                    app.Response.AddHeader("Content-Type", "application/json");
                    app.Response.End();
                }
            }
            
        }

        // Check if the request has a "Referer" header
        private bool CheckRefererHeader(HttpRequest request)
        {
            var isAccepted = false;
            if (request.Headers["Referer"] != null)
            {
                if (acceptedUrls.Contains(request.Headers["Referer"]))
                {
                    isAccepted = true;
                }
            }
            return isAccepted;
        }

        // Check if the request has a recognized "Origin" header
        private bool CheckOriginHeader(HttpRequest request)
        {
            var isAccepted = false;
            if (request.Headers["Origin"] != null)
            {
                if (acceptedOrigins.Contains(request.Headers["Origin"]))
                {
                    isAccepted = true;
                }
            }
            return isAccepted;
        }

        // Check if the request Url authority is used
        private bool CheckUrlAuthority(HttpRequest request)
        {
            var isAccepted = false;
            if (request.Url.Authority != null)
            {
                // Is it a recognized Url?
                if (acceptedAuthorities.Contains(request.Url.Authority))
                {
                    isAccepted = true;
                }
            }
            return isAccepted;
        }
    }
}