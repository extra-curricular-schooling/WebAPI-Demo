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
    /// This model represents any access token that has reached its expiration time.
    /// </summary>
    public class ExpiredAccessToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpiredTokenId { get; set; }

        [Required]
        public string ExpiredTokenValue { get; set; }

        [Required]
        public bool CanReuse { get; set; }
    }
}
