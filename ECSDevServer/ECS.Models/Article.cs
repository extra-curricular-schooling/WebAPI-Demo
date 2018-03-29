using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary>
    /// The model represents the storage of article information from articles grabbed by our web crawler.
    /// Each account can have multiple articles attached to it.
    /// </summary>
    public class Article
    {
        // Display is not right impleneation for column names, use Column(name:..)
        // The name of the article stored.
        [Required]
        public string ArticleTitle { get; set; }

        // The full URL link of the article stored
        [Key]
        [Required]
        public string ArticleLink { get; set; }

        // A brief description that is attached to the article stored.
        public string ArticleDescription { get; set; }

        /// <summary>
        /// Will hold the Type of Article it is. ie. Technology, Medical, Business, etc.
        /// </summary>
        //[Required]
        public string TagName { get; set; }

        // Navigation Property of Interest Tag
        public virtual InterestTag InterestTag { get; set; }


        /**
        Navigation Property of Account
        Implementation of Account History
        public virtual ICollection<Account> Account { get; set; }
        **/
    }
}
