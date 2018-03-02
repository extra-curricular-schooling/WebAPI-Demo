using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    /// <summary>
    /// This model represents an account in the ECS system.  It contains non-personal information, excluding
    /// an email attribute which is used to map with the Users model.  An account can have many Security
    /// Questions as well as many Interest tags and Articles.
    /// </summary>
    public class Account
    {
        //Primary Key
        [Key]
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        //Foreign Key: comes from User model
        [Required]
        public string Email { get; set; }

        //Will be a hashed string about 44 characters, but for now it is plain text
        [Required]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5-20 characters")]
        public string Password { get; set; }

        //Amount of points acquired from reading articles
        [Display(Name = "Points")]
        public int Points { get; set; }

        //True means account is enabled, False means account is disabled
        [Required]
        [Display(Name = "Account Status")]
        public bool AccountStatus { get; set; }

        //If account status = disabled suspension time will give a duration
        [DataType(DataType.Date)]
        [Display(Name = "Suspension Time")]
        public DateTime SuspensionTime { get; set; }

        //Navigation Property for foreign key
        public virtual User User { get; set; }

        //Navigation Property of many to many relationship
        public virtual ICollection<SecurityQuestionAccount> SecurityAnswers { get; set; }

        //Navigation Property of many to many relationship
        public virtual ICollection<InterestTag> AccountTags { get; set; }

        //Navigation Property of many to many relationship
        //Implementation of Account History
        //public virtual ICollection<Article> Article { get; set; }
    }
}
