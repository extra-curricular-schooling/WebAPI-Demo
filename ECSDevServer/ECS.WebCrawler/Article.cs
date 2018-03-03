using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECS.WebCrawler
{
    /// <summary>
    /// Model for Articles
    /// </summary>
    [Table("articleListing")]
    public class Article
    {
        /// <summary>
        /// Will hold the URL for the article. Used as the Primary Key for the DB.
        /// </summary>
        [Key]
        public string ArticleLink { get; set; }

        /// <summary>
        /// Will hold the Type of Article it is. ie. Technology, Medical, Business, etc.
        /// </summary>
        public string ArticleType { get; set; }

        /// <summary>
        /// Will hold the Title of the Article.
        /// </summary>
        public string ArticleTitle { get; set; }

        /// <summary>
        /// Will hold the article description
        /// </summary>
        public string ArticleDescription { get; set; }

    }
}
