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
                bool isTrusted = false;
                bool isAcceptedUrlAuthorityHeader = false;
                bool isAcceptedRefererHeader = false;
                bool isAcceptedOriginHeader = false;
                bool isBadRequest = false;

                // Check if the request has a "Referer" header
                if (request.Headers["Referer"] != null && !isTrusted)
                {
                    if (acceptedUrls.Contains(request.Headers["Referer"]))
                    {
                        isAcceptedRefererHeader = true;
                        isTrusted = true;
                    }
                    else
                    {
                        isBadRequest = true;
                    }

                }

                // Check if the request has a recognized "Origin" header
                if (request.Headers["Origin"] != null && !isTrusted)
                {
                    if (acceptedOrigins.Contains(request.Headers["Origin"]))
                    {
                        isAcceptedOriginHeader = true;
                        isTrusted = true;
                    }
                    else
                    {
                        isBadRequest = true;
                    }
                }

                // Check if the request Url authority is used
                if (request.Url.Authority != null && !isTrusted)
                {
                    // Is it a recognized Url?
                    if (acceptedAuthorities.Contains(request.Url.Authority))
                    {
                        isAcceptedUrlAuthorityHeader = true;
                        isTrusted = true;
                    }
                    else
                    {
                        isBadRequest = true;
                    }
                }

                // Return the bad request
                if (!isAcceptedRefererHeader && !isAcceptedOriginHeader && !isAcceptedUrlAuthorityHeader && !isBadRequest)
                {
                    // Http Status Code 403: Request is correct, but our API refuses to serve for this request.
                    app.Response.StatusCode = 403;
                    app.Response.End();
                }

                // For Preflight
                if (app.Request.HttpMethod == "OPTIONS" && isTrusted)
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
    }
}