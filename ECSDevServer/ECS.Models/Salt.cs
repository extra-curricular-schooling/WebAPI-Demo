using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the salt used when hasfing the username's password.
    /// </summary>
    public class Salt
    {
        // Salt identifier
        [Key]
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
        public Account Account { get; set; }
    }
}
