using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DataAccess.Models
{
    /// <summary>
    /// This model represents the available permissions with the role asscoiated to each.
    /// </summary>
    public class Permission
    {
        // Name/value of the permission Foreign Key of role
        [Required]
        [Key]
        [Column(Order = 0)]
        public string PermissionName { get; set; }
    }
}
