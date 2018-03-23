using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    public class SaltSecurityAnswer
    {
        [Key]
        public int SaltId { get; set; }

        public string SaltValue { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Security Questions")]
        public int SecurityQuestionID { get; set; }

        public Account Accounts { get; set; }

        public SecurityQuestion Answers { get; set; }
    }
}
