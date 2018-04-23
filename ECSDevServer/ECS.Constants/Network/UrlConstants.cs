using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Constants.Network
{
    public static class UrlConstants
    {
        public const string BaseAppServer = "https://localhost:44311";
        public static readonly ISet<string> AcceptedAuthorities = new HashSet<string>
        {
            "localhost:44311"
        };
        public static readonly ISet<string> AcceptedUrls = new HashSet<string>
        {
            "https://localhost:44311/",
            "http://localhost:8080/",
            "https://www.ecschooling.org/",
            "https://ecschooling.org/",
            "https://fannbrian.github.io/"
        };
        public static readonly ISet<string> AcceptedOrigins = new HashSet<string>
        {
            "http://localhost:8080",
            "https://www.ecschooling.org",
            "https://ecschooling.org"
        };  
    }
}
