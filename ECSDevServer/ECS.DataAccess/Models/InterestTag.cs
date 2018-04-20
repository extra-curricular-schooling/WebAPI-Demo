using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DataAccess.Models
{
    /// <summary>
    /// This model represents the Interest Tags associated with Accounts.  They are unique names used to sort through
    /// different articles with similar or equal tags.
    /// </summary>
    public class InterestTag
    {
        // The name of the interest tag
        [Key]
        [Required]
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }

        // Navigation Property
        // Create constructor ACcountUsername = List<Account>
        public virtual ICollection<Account> AccountUsername { get; set; }

        // Navigation Property
        public virtual ICollection<Article> ArticleTags { get; set; }

        public InterestTag()
        {
            this.AccountUsername = new List<Account>();
            this.ArticleTags = new List<Article>();
        }
    }
}
