using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary>
    /// Add an authentication method for validation before submitting to database 
    /// This model represents permissions linked with accounts in the ECS system.  
    /// </summary>
    public class AccountType
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Permission { get; set; }

        //foreign key
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string Username { get; set; }

        //Navigation Property
        public Account Account { get; set; }
    }
}
