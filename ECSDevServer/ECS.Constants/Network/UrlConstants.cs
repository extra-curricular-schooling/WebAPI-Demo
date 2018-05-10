using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Constants.Network
{
    /// <summary>
    /// Application URL constants.
    /// </summary>
    public static class UrlConstants
    {
        public const string BaseAppClient = "http://localhost:8080/";

        public const string BaseAppServer = "https://localhost:44311/";

         public static readonly ISet<string> AcceptedAuthorities = new HashSet<string> 
        { 
            "localhost:44311",
            "localhost:44311", 
            "www.ecschooling.org:80", 
            "www.ecschooling.org:443", 
            "ecschooling.org:80", 
            "ecschooling.org:443", 
        }; 
 
        public static readonly ISet<string> AcceptedUrls = new HashSet<string> 
        { 
            "https://localhost:44311/", 
            "http://localhost:8080/",
            "http://localhost:8085/",
            "https://localhost:8085/",
            "http://www.ecschooling.org:80/",  
            "https://www.ecschooling.org:443/",
            "http://ecschooling.org:80/",  
            "https://ecschooling.org:443/", 
            "https://fannbrian.github.io:443/" 
        }; 
 
        public static readonly ISet<string> AcceptedOrigins = new HashSet<string> 
        { 
            "http://localhost:8080",
            "http://localhost:8085",
            "http://www.ecschooling.org",  
            "https://www.ecschooling.org", 
            "http://ecschooling.org",  
            "https://ecschooling.org", 
            "https://fannbrian.github.io" 
        };  
    }
}
