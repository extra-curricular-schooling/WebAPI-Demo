﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the cookies that are acreated when a user attempts to login.  This cookie can be refrenced
    /// at any time as long as it is not past its expiration date from when it was created.
    /// </summary>
    public class Cookie
    {
        //Where the cookie was created from
        [Required]
        public string Domain { get; set; }

        //The time the cookie was created
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreatedSessionCookie { get; set; }

        //UniqueID of cookie for easy authentication and referencing
        [Key]
        public int SessionID { get; set; }

        //The time when the cookie is no longer valid
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        //The filepath when the cookie was created
        public string Path { get; set; }

        //foreign key of User class
        public string Email { get; set; }

        //navigation property of User class
        public virtual User User { get; set; }

    }
}
