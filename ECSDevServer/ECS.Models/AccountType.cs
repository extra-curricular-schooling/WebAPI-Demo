using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary> 
    /// This model represents permissions linked with accounts in the ECS system.  
    /// </summary>
    public class AccountType
    {

        // Foreign Key
        // What a specific user can/cannot do
        // Potentially will be a foreign key from Permission for extensibility
        [Key]
        [Column(Order = 1)]
        [Required]
        public string PermissionName { get; set; }


        // Foreign Key
        // Defines what type of user
        // Potentially will be a foreign key from Permissions for extensibility
        //[Required]
        //[Display(Name = "Role ID")]
        //public int RoleId{ get; set; }

        // Foreign key coming from Account
        [Key]
        [Column(Order = 0)]
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, 
            ErrorMessage = "Username must be between 5-20 characters")]
        public string Username { get; set; }

        // Navigation Property
        public Account Account { get; set; }

        // Navigation Property
        // Should be a collection of permissions
        public Permission Permission { get; set; }
    }
}
