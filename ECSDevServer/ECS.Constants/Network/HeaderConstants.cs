using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Constants.Network
{
    public static class HeaderConstants
    {
        /// <summary>
        /// Comma Separated List of accepted headers
        /// </summary>
        public const string AcceptedHeaders =
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

        public const string Origin = "Origin";

        public const string Referer = "Referer";
    }
}
