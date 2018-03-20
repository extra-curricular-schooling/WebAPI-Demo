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

                var isAcceptedRefererHeader = CheckRefererHeader(request);
                var isAcceptedOriginHeader = CheckOriginHeader(request);
                var isAcceptedUrlAuthorityHeader = CheckUrlAuthority(request);

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
            return request.Headers["Referer"] != null && _acceptedUrls.Contains(request.Headers["Referer"]);
        }

        // Check if the request has a recognized "Origin" header
        private bool CheckOriginHeader(HttpRequest request)
        {
            return request.Headers["Origin"] != null && _acceptedOrigins.Contains(request.Headers["Origin"]);
        }

        // Check if the request Url authority is used
        private bool CheckUrlAuthority(HttpRequest request)
        {
            return _acceptedAuthorities.Contains(request.Url.Authority);
        }
    }
}