using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Constants.Security
{
    public static class ClaimValues
    {
        // Actionable Permissions
        public const string CanCreateUser = "CanCreateUser";

        public const string CanDeleteUser = "CanDeleteUser";
        
        public const string CanModifyUser = "CanModifyUser";
        
        public const string CanEditInformation = "CanEditInformation";
        
        public const string CanEnableUser = "CanEnableUser";
        
        public const string CanDisableUser = "CanDisableUser";
        
        public const string CanEnterRaffle = "CanEnterRaffle";
        
        public const string CanViewArticle = "CanViewArticle";

        // Role Claims
        public const string Admin = "Admin";
        
        public const string Scholar = "Scholar";

        // Other
        public const string Ecs = "ecs";

    }
}
