using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the roles implemented in ECS identified by an ID
    /// </summary>
    public class Role
    {
        // Identifier of the role
        public int RoleId { get; set; }

        // Name of the role
        [Required]
        public string RoleName { get; set; }

        // Navigation Property
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
