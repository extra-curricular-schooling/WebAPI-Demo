namespace ECS.Constants.Network
{
    public static class CorsConstants
    {
        public const string BaseAcceptedOrigins = 
            "http://localhost:8080, " +
            "http://localhost:8081, " +
            "https://ecschooling.org, " +
            "https://www.ecschooling.org, " +
            "https://sso.com";

        public const string BaseAcceptedHeaders = "*";
    }
}
