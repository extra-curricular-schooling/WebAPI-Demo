using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECS.Models;
using ECS.Repositories;

namespace ECS.WebCrawler
{
    /// <summary>
    /// Crawls through a homepage to aggregrate articles, crawls through the articles to validate tags, stores valid articles to DB.
    /// Implements ICrawler
    /// </summary>
    public class BaseCrawler : ICrawler
    {
        private readonly IArticleRepository articleRepository = new ArticleRepository();
        private readonly IInterestTagRepository interestTagRepository = new InterestTagRepository();
        /// <summary>
        /// A List of KeyValuePair of (Strings and List of Strings)
        /// Key will be the URL String
        /// Value will be a list of strings consisting of attributes necessary to traverse through the html files.
        /// </summary>
        private List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };

        /// <summary>
        /// A HashSet of Strings. Will be used validate articles.
        /// </summary>
        private HashSet<string> Tags = new HashSet<string> { };

        /// <summary>
        /// Two-Parameter Constructor.
        /// </summary>
        /// <param name="Sites"></param>
        /// <param name="Tags"></param>
        public BaseCrawler(List<KeyValuePair<string, List<string>>> Sites, HashSet<string> Tags)
        {
            this.Sites = Sites;
            this.Tags = Tags;
        }

        /// <summary>
        /// Starts the asynchronous crawler and stores to DB.
        /// </summary>
        /// <returns> Completed Task </returns>
        public async Task CrawlingAsync()
        {
            // Calls startCrawler with the given sites and stores valid articles to toStore.
            List<ECS.Models.Article> toStore = await StartCrawler(Sites);

            // Instantiate new DBContext
            //ArticleContext storer = new ArticleContext();
            //ECS.Models.ECSContext.ECSContext storer = new ECS.Models.ECSContext.ECSContext();

            // Go through each article and store if not already in DB.
            foreach (var article in toStore)
            {
                try
                {

                    //if (!storer.Articles.Any(a => a.ArticleLink == article.ArticleLink))
                    if (!articleRepository.Exists(a => a.ArticleLink == article.ArticleLink))
                    {
                        articleRepository.Insert(article);
                        Console.WriteLine($"{article.ArticleTitle} added for {article.TagName}");
                    }
                }
                // Catch if DBContext fails to save.
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + article.ArticleLink + " response: " + e.Message);
                    foreach (var validationErrors in e.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the HomeCrawler and ArticleCrawler
        /// </summary>
        /// <param name="Sites"></param>
        /// <returns>Valid Articles</returns>
        private async Task<List<ECS.Models.Article>> StartCrawler(List<KeyValuePair<string, List<string>>> Sites)
        {

            // Links will hold the links gathered from the homepage.
            List<string[]> links = new List<string[]>();

            // For each site from given Sites. Crawl through and gather article links.
            foreach (var site in Sites)
            {
                List<string> attributes = site.Value;
                List<string> link = (await HomeCrawler(site.Key, attributes));
                foreach (var urlLink in link)
                {
                    string[] linkInfo = { urlLink, site.Key };
                    links.Add(linkInfo);
                }

            }

            return await ArticleCrawler(links);
        }


        /// <summary>
        /// Crawls through given site for articles.
        /// </summary>
        /// <param name="url"> Site URL </param>
        /// <param name="attributes"> Attributes needed to traverse site </param>
        /// <returns> List of Strings of article links </returns>
        public async Task<List<string>> HomeCrawler(string url, List<string> attributes)
        {
            // Will hold the links for the articles.
            var links = new List<string>();
            try
            {
                // Initiate new HttpClient to request HTML.
                var httpClient = new HttpClient();
                // Gather the HTML data from the give url.
                var html = await httpClient.GetStringAsync(url);
                // Initiate new HtmlDocument object to load the HTMl.
                var htmlDoc = new HtmlDocument();
                // load gathered HTMl.
                htmlDoc.LoadHtml(html);
                try
                {
                    // Gather the blocks from each [attribute[0]] where [attribute[1]] = [attribute[2]]. ie. Gather the blocks from each "div" where "class"= "article--header"
                    var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();

                    // For each block. Gather the [attribute[3]].[attribute[4]] and add to links. ie. From each block, gather the "a"."href"
                    foreach (var li in blocks)
                    {
                        var articleLink = li.Descendants(attributes[3]).FirstOrDefault().ChildAttributes(attributes[4]).FirstOrDefault().Value;
                        // If the gathered link is only a relative link without the full url. Append the url found in attribute[5]
                        if (articleLink.Substring(0, 4) != "http")
                        {
                            articleLink = attributes[5] + articleLink;
                        }

                        links.Add(articleLink);
                    }
                }
                // Catch NullReferenceException if it fails to locate a block via the attributes
                catch (NullReferenceException e)
                {
                    Console.WriteLine(DateTime.Now + ": Received an '" + e.Message + "' Error from " + url);
                }

            }
            // Catch HttpRequestException if it fails to get a response from requested site.
            catch (HttpRequestException e)
            {
                Console.WriteLine(DateTime.Now + ": Site " + url + " response: " + e.Message);
            }
            return links;
        }

        /// <summary>
        /// Crawl through aggregated links and check if its a valid article for the site.
        /// </summary>
        /// <param name="links"> List of gathered links</param>
        /// <returns> List of valid Articles </returns>
        public async Task<List<ECS.Models.Article>> ArticleCrawler(List<string[]> links)
        {
            // Will hold the valid Articles.
            var list = new List<ECS.Models.Article>();

            // Initiate new httpclient and htmlDocument to request and traverse html.
            var httpClient = new HttpClient();
            var htmlDoc = new HtmlDocument();

            // Will hold the article info.
            string tags = "";
            string title = "";
            string description = "";

            // Boolean to check if article matches a keyword/tag
            bool tagMatch = false;

            // For each article, check if valid
            foreach (var art in links)
            {
                try
                {
                    // Will hold the proper attributes for the site.
                    List<string> siteAttribute = null;
                    var html = await httpClient.GetStringAsync(art[0]);
                    htmlDoc.LoadHtml(html);

                    // Associate the proper attributes for the Site. 
                    foreach (var site in Sites)
                    {
                        if (site.Key == art[1])
                        {
                            siteAttribute = site.Value;
                            break;
                        }
                    }

                    // Gather the blocks where the keywords/tags are held in the article. 
                    var tagList = htmlDoc.DocumentNode.Descendants(siteAttribute[6]).Where(node => node.GetAttributeValue(siteAttribute[7], "").Equals(siteAttribute[8])).ToList();

                    // Gather each tag from the block.
                    foreach (var lt in tagList)
                    {
                        tags = lt.GetAttributeValue(siteAttribute[9], "");
                    }

                    // Lowercase the tags for easier comparison
                    tags = tags.ToLower();

                    // Reset tagMatch to false.
                    tagMatch = false;

                    // Replace any ',' if site stored tags as a CSV.
                    tags = tags.Replace(",", "");

                    // Split up tags 
                    string[] contentTags = tags.Split(' ');
                    int tagCount = 0;

                    // For each tag in list, check if it is contained in HashSet of valid tags. If so, tagMatch = true, assign hit tag to Article tag then break.
                    foreach (var t in contentTags)
                    {
                        Console.WriteLine($"The tag[{tagCount++}]:{t}");
                        if (Tags.Contains(t))
                        {
                            Console.WriteLine($"Tag Hit with {t}");
                            tagMatch = true;
                            break;
                        }
                    }

                    // If tagMatched, gather the rest of the necessary Article information.
                    if (tagMatch)
                    {
                        // Gather blocks that hold the Title information and store to title.
                        var titleHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[10]).Where(node => node.GetAttributeValue(siteAttribute[11], "").Equals(siteAttribute[12]));
                        foreach (var titleName in titleHolder)
                        {
                            title = titleName.GetAttributeValue(siteAttribute[13], "");
                        }

                        // Gather blocks that hold the Description information and store to description.
                        var descriptionHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[14]).Where(node => node.GetAttributeValue(siteAttribute[15], "").Equals(siteAttribute[16]));
                        foreach (var descriptionString in descriptionHolder)
                        {
                            description = descriptionString.GetAttributeValue(siteAttribute[17], "");
                        }

                        InterestTag tag = interestTagRepository.GetSingle(d => d.TagName.Equals(siteAttribute[18]));
                        if (title.Length > 45)
                        {
                            title = title.Substring(0, 45) + "...";
                        }

                        if (description.Length > 45)
                        {
                            description = description.Substring(0, 45) + "...";
                        }

                        // Create new Article Object and assign the gathered variables.
                        var goodArticle = new ECS.Models.Article
                        {
                            // Assigns articleType by attribute[18]. ie. Technology, Medical, etc.
                            TagName = tag.TagName,
                            ArticleTitle = title,
                            // Assigns the articleLink as the url from the article that is being crawled.
                            ArticleLink = art[0],
                            ArticleDescription = description

                        };

                        // Ran into some articles that did not have a Title, decided to make the description the title.
                        if (goodArticle.ArticleTitle == "")
                        {
                            goodArticle.ArticleTitle = goodArticle.ArticleDescription;
                        }

                        // Add the valid article to the list of valid articles.
                        list.Add(goodArticle);
                    }
                    else
                    {
                        Console.WriteLine($"{art[0]} not added to {siteAttribute[18]}");
                    }

                }
                // Catch HttpRequestException if it fails to get a response from requested article.
                catch (HttpRequestException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + art[0] + " response: " + e.Message);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(DateTime.Now + ": Received an '" + e.Message + "' Error from " + art[0]);
                }
            }
            return list;
        }
    }
}
