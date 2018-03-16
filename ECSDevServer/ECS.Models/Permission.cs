using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the available permissions with the role asscoiated to each.
    /// </summary>
    public class Permission
    {
        // Foreign Key of Role
        [Key]
        [Column(Order = 1)]
        public int RoleId { get; set; }

        // Name/value of the permission Foreign Key of role
        [Required]
        [Key]
        [Column(Order = 0)]
        public string PermissionName { get; set; }

        // Navigation Property of Role
        public Role Role { get; set; }
    }
}
