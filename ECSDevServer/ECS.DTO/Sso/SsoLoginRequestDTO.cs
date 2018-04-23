using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DTO.Sso
{
    public class SsoLoginRequestDTO
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string RoleType { get; set; }
    }
}
