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
    /// This model represents any malformed or unaccepted token detected during authentication.
    /// </summary>
    public class BadAccessToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BadTokenId { get; set; }

        [Required]
        public string BadTokenValue { get; set; }
    }
}
