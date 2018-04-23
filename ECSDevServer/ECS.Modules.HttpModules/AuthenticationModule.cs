using System;
using System.Collections.Generic;
using System.Web;
using ECS.Constants.Network;

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
        private readonly ISet<string> _acceptedUrls = UrlConstants.AcceptedUrls;

        // List of project accepted authority header value.
        private readonly ISet<string> _acceptedAuthorities = UrlConstants.AcceptedAuthorities;

        // List of accepted orgin header values
        private readonly ISet<string> _acceptedOrigins = UrlConstants.AcceptedOrigins;

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
                    app.Response.AddHeader("Access-Control-Allow-Headers", HeaderConstants.AcceptedHeaders);
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