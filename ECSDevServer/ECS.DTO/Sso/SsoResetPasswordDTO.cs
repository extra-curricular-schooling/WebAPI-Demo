using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DTO.Sso
{
    public class SsoResetPasswordDTO
    {

        public string Username { get; set; }

        public string NewPassword { get; set; }

        public string PasswordSalt { get; set; }

        public string HashedNewPassword { get; set; }
    }
}
