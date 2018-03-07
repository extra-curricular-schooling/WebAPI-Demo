using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Models
{
    /// <summary>
    /// The model represents the storage of article information from articles grabbed by our web crawler.
    /// Each account can have multiple articles attached to it.
    /// </summary>
    public class Article
    {
        //The name of the article stored.
        [Required]
        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }

        //The full URL link of the article stored
        [Key]
        [Required]
        [Display(Name = "Article Link")]
        public string ArticleLink { get; set; }

        //A brief description that is attached to the article stored.
        [Display(Name = "Article Description")]
        public string ArticleDescription { get; set; }

        //Navigation Property of Interest Tag
        public virtual InterestTag InterestTag { get; set; }


        /**Hugo says we don't need
        [Required, Display(Name = "Article Tag")]
        public string ArticleTag { get; set; }
        Link Article with Interest Tag

        Navigation Property of Account
        Implementation of Account History
        public virtual ICollection<Account> Account { get; set; }
        **/
    }
}
