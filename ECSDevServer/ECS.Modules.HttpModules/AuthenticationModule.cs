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
        List<string> acceptedUrls = new List<string>
        {
            "https://localhost:44311/",
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

            // bool isAcceptedUrlHeader = false;
            bool isAcceptedRefererHeader = false;
            bool isAcceptedOriginHeader = false;
            //if (request.Headers["Url"] != null && acceptedUrls.Contains(request.Headers["Url"]))
            //{
            //    isAcceptedUrlHeader = true;
            //}
            if (request.Headers["Referer"] != null && acceptedUrls.Contains(request.Headers["Referer"]))
            {
                isAcceptedRefererHeader = true;
            }
            if (request.Headers["Origin"] != null && acceptedOrigins.Contains(request.Headers["Origin"]))
            {
                isAcceptedOriginHeader = true;
            }
            if (!isAcceptedRefererHeader && !isAcceptedOriginHeader)
            {
                app.Response.StatusCode = 401;
                app.Response.End();
            }
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
                app.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
                app.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                app.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                app.Response.AddHeader("Content-Type", "application/json");
                app.Response.End();
            }
        }
    }
}
