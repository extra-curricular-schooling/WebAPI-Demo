using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DTO.Sso
{
    /// <summary>
    /// Login Data Transfer Object for traversing multiple application layers.
    /// </summary>
    public class SsoLoginRequestDTO
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string RoleType { get; set; }
    }
}
