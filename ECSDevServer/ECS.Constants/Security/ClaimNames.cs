using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Constants.Security
{
    /// <summary>
    /// Application Claim Names
    /// </summary>
    public static class ClaimNames
    {
        public const string Username = "username";

        public const string Password = "password";

        public const string Role = "role";

        // RoleType is for SSO. It is a generic role that needs to be interpreted
        // to be a role that our application supports.
        public const string RoleType = "roleType";

        public const string Application = "application";
    }
}
