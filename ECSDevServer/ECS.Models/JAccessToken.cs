using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the tokens passed from the server, JWT, which is just
    /// a hashed string.
    /// </summary>
    // should be named ACcess token not JWT
    public class JAccessToken
    {
        //Consists of claims, expiration date, where it comes from
        [Required]
        [Column(Order = 2)]
        public string Value { get; set; }

        //Foreign Key of Account
        [Column(Order = 0)]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        //Identifier for JWT's
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenId { get; set; }

        [Required]
        public DateTime DateTimeIssued { get; set; }

        //Navigation Property of User
        public Account Account { get; set; }
    }
}
