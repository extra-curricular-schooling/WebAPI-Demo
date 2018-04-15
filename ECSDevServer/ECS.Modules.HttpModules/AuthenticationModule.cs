using System;
using System.Collections.Generic;
using System.Web;

namespace ECS.Modules.HttpModules
{
    internal class AuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnHttpRequest;
        }

        // List of accepted referrer header values.
        private readonly HashSet<string> _acceptedUrls = new HashSet<string>
        {
            "https://localhost:44311/",
            "http://localhost:8080/",
            "https://www.ecschooling.org/",
            "https://ecschooling.org/"
        };

        private readonly HashSet<string> _acceptedAuthorities = new HashSet<string>
        {
            "localhost:44311"
        };

        // List of accepted orgin header values
        private readonly HashSet<string> _acceptedOrigins = new HashSet<string>
        {
            "http://localhost:8080",
            "https://www.ecschooling.org",
            "https://ecschooling.org"
        };

        private void OnHttpRequest(object sender, EventArgs e)
        {
            // Cast the sender as an HttpApplication

            if (sender is HttpApplication app && app.Request.GetType().Name.Equals("HttpRequest"))
            {
                var request = app.Request;
                var type = request.GetType();

                var isAcceptedRefererHeader = request.Headers["Referer"] != null && _acceptedUrls.Contains(request.Headers["Referer"]);
                var isAcceptedOriginHeader = request.Headers["Origin"] != null && _acceptedOrigins.Contains(request.Headers["Origin"]);
                var isAcceptedUrlAuthorityHeader = _acceptedAuthorities.Contains(request.Url.Authority);

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
                if (app.Request.HttpMethod == "OPTIONS" && isAcceptedOriginHeader)
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
                    app.Response.AddHeader("Access-Control-Expose-Headers", "location");
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