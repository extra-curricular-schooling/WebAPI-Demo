using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DataAccess.Models
{
    public class PartialAccountSalt
    {
        // Salt identifier
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaltId { get; set; }

        // String used to salt the password
        [Required]
        public string PasswordSalt { get; set; }

        // The account name with its given salt
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        //Navigation property for the username
        public PartialAccount PartialAccount { get; set; }
    }
}
