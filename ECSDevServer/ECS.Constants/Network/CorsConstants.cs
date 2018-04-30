namespace ECS.Constants.Network
{
    public static class CorsConstants
    {
        /// <summary>
        /// Comma separated list of accepted origins.
        /// </summary>
        public const string BaseAcceptedOrigins = 
            "http://localhost:8080, " +
            "http://localhost:8081, " +
            "https://ecschooling.org, " +
            "https://www.ecschooling.org, " +
            "https://sso.com, " +
            "https://fannbrian.github.io";

        /// <summary>
        /// Comma separated list of accepted headers.
        /// </summary>
        public const string BaseAcceptedHeaders =
            "Access-Control-Allow-Headers," +
            "Access-Control-Allow-Origin," +
            "Access-Control-Allow-Credentials," +
            "Authorization," +
            "origin," +
            "accept," +
            "content-type," +
            "referer," +
            "X-Requested-With," +
            "xsrfCookieName," +
            "xsrfHeaderName";
    }
}
