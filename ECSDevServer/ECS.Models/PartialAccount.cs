using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{
    public class PartialAccount
    {
        [Key]
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        // Will be a hashed string about 44 characters, but for now it is plain text
        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be between 5-20 characters")]
        public string Password { get; set; }


        // Talk about this being a like to Permissions.
        [Required]
        public string AccountType { get; set; }
    }
}
