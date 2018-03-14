using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the LinkedIn access tokens used to create a LinkedIn post.  An account can only
    /// have one access token.
    /// </summary>
    public class LinkedIn
    {
        //Identifier for JWT's
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenId { get; set; }

        //Foreign Key of Account class
        [Required]
        [Column(Order = 1)]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        //The token produced as a string to create a LinkedIn post
        [Required]
        [Column(Order = 2)]
        [StringLength(2000)]
        public string AccessToken { get; set; }

        //The date and time the token was created
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Token Creation")]
        public DateTime TokenCreation { get; set; }

        public bool Expired { get; set; }

        //navigation property of Account
        //token has one Account
        public Account Account { get; set; }

        public LinkedIn()
        {
            Expired = false;
        }
    }
}
