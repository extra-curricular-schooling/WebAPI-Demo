using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the tokens passed from the server, JWT, which is just
    /// a hashed string.
    /// </summary>
    public class JWT
    {
        //Identifier for JWT's
        [Key]
        public int JWTID { get; set; }

        //Consists of claims, expiration date, where it comes from
        public string Token { get; set; }

        //Foreign Key of user
        public string Email { get; set; }

        //Navigation Property of User
        public User User { get; set; }
    }
}
