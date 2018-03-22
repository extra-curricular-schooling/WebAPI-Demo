using Xunit;
using Moq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ECS.WebCrawler.Tests
{
    public class WebCrawlerTests
    {

        // Article Model
        public class Article
        {
            public string ArticleTitle { get; set; }
            public string ArticleLink { get; set; }
            public string ArticleDescription { get; set; }
            public string TagName { get; set; }
        }




        public class HomeCrawler
        {

            /// <summary>
            /// Test to request the html from a site
            /// </summary>
            [Fact]
            public async void HomeCrawler_ReturnHTMLString()
            {
                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });


                // Act
                TestSite testSite = new TestSite();
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(siteAttributes.Key);


                // Assert
                Assert.Equal(testSite.SiteHtml, html);

            }

            
            /// <summary>
            ///  Test to load the div blocks from a site
            /// </summary>
            [Fact]
            public async void HomeCrawler_LoadHTMLBlocks()
            {
                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> attributes = siteAttributes.Value;

                // Act
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(siteAttributes.Key);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();


                // Assert
                Assert.Equal(5, blocks.Count);

            }


            /// <summary>
            /// Test to gather article links from a site
            /// </summary>
            [Fact]
            public async void HomeCrawler_GatherArticles()
            {
                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> {
                    "http://hugogarcia.me/site/testSite1.html",
                    "http://www.hugogarcia.me/site/testSite2.html",
                    "http://hugogarcia.me/site/testSite3.html",
                    "http://hugogarcia.me/site/testSite4.html",
                    "http://hugogarcia.me/site/testSite5.html"
                };


                // Act
                List<string> attributes = siteAttributes.Value;
                var links = new List<string>();
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(siteAttributes.Key);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);


                var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();
                foreach (var li in blocks)
                {
                    var articleLink = li.Descendants(attributes[3]).FirstOrDefault().ChildAttributes(attributes[4]).FirstOrDefault().Value;
                    if (articleLink.Substring(0, 4) != "http")
                    {
                        articleLink = attributes[5] + articleLink;
                    }

                    links.Add(articleLink);
                }


                // Assert
                Assert.Equal(actualLinks, links);
            }


            /// <summary>
            /// Test to gather the tags from an article via the meta tag
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherTags()
            {

                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                string[] actualTags = { "test", "testing", "tester", "blah", "bla", "foo","bar"};
                List<string> links = new List<string> { "http://hugogarcia.me/site/testSite1.html" };

                string tags = "";
                string[] contentTags = { };

                // Act
                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();

                foreach (var art in links)
                {

                    // load the site html
                    var html = await httpClient.GetStringAsync(art);
                    htmlDoc.LoadHtml(html);

                    // Associate the proper attributes for the Site. 
                    List<string> siteAttribute = siteAttributes.Value;

                    // Gather the blocks where the keywords/tags are held in the article. 
                    var tagList = htmlDoc.DocumentNode.Descendants(siteAttribute[6]).Where(node => node.GetAttributeValue(siteAttribute[7], "").Equals(siteAttribute[8])).ToList();

                    // Gather each tag from the block.
                    foreach (var lt in tagList)
                    {
                        tags = lt.GetAttributeValue(siteAttribute[9], "");
                    }

                    // Lowercase the tags for easier comparison
                    tags = tags.ToLower();

                    // Replace any ',' if site stored tags as a CSV.
                    tags = tags.Replace(",", "");

                    // Split up tags 
                    contentTags = tags.Split(' ');
                }

                // Assert
                Assert.Equal(actualTags, contentTags);
            }


            /// <summary>
            /// Test to match tags to tags we are looking for. Test should pass due to match.
            /// </summary>
            /// <param name="contentTags"></param>
            [Theory]
            [InlineData(new object[] { new string[] { "test", "testing", "1", "2", "4" } })]
            public void ArticleCrawler_MatchTagsTrue(string[] contentTags)
            {
                // Arrange
                bool tagMatch = false;
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                // Act
                foreach (var t in contentTags)
                {
                    if (Tags.Contains(t))
                    {
                        tagMatch = true;
                        break;
                    }
                }

                // Assert
                Assert.True(tagMatch);
                
            }

            /// <summary>
            /// Test to match tags to tags we are looking for. Test should pass due to no match.
            /// </summary>
            /// <param name="contentTags"></param>
            [Theory]
            [InlineData(new object[] { new string[] { "testing", "testing", "1", "2", "4" } })]
            public void ArticleCrawler_MatchTagsFalse(string[] contentTags)
            {
                // Arrange
                bool tagMatch = false;
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                // Act
                foreach (var t in contentTags)
                {
                    if (Tags.Contains(t))
                    {
                        tagMatch = true;
                        break;
                    }
                }

                // Assert
                Assert.False(tagMatch);
                
            }


            /// <summary>
            /// Test to add accepted articles to a list
            /// </summary>
            [Fact]
            public async void ArticleCrawler_AcceptArticles()
            {
                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };
                List<Article> testArticles = new List<Article> {
                new Article() {ArticleLink = "http://hugogarcia.me/site/testSite1.html", TagName= "Testing", ArticleTitle="testing testing 1 2 4", ArticleDescription ="This is testSite 1" },
                new Article() {ArticleLink = "http://www.hugogarcia.me/site/testSite2.html", TagName= "Testing", ArticleTitle="testing testing 1 2 4", ArticleDescription ="This is testSite 2" },
                new Article() {ArticleLink = "http://hugogarcia.me/site/testSite4.html", TagName= "Testing", ArticleTitle="testing testing 1 2 4", ArticleDescription ="This is testSite 4" },
                new Article() {ArticleLink = "http://hugogarcia.me/site/testSite5.html", TagName= "Testing", ArticleTitle="testing testing 1 2 4", ArticleDescription ="This is testSite 5" },
                };
                List<string> actualLinks = new List<string> {
                    "http://hugogarcia.me/site/testSite1.html",
                    "http://www.hugogarcia.me/site/testSite2.html",
                    "http://hugogarcia.me/site/testSite3.html",
                    "http://hugogarcia.me/site/testSite4.html",
                    "http://hugogarcia.me/site/testSite5.html"
                };

                // Act
                var links = actualLinks;
                List<string> list = new List<string>();
                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();

                // Will hold the article info.
                string tags = "";

                // Boolean to check if article matches a keyword/tag
                bool tagMatch = false;

                // For each article, check if valid
                foreach (var art in links)
                {

                    // Will hold the proper attributes for the site.
                    var html = await httpClient.GetStringAsync(art);
                    htmlDoc.LoadHtml(html);

                    // Associate the proper attributes for the Site. 
                    List<string> siteAttribute = siteAttributes.Value;

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

                    // For each tag in list, check if it is contained in HashSet of valid tags. If so, tagMatch = true, assign hit tag to Article tag then break.
                    foreach (var t in contentTags)
                    {
                        if (Tags.Contains(t))
                        {
                            tagMatch = true;

                            break;
                        }
                    }

                    if (tagMatch)
                    {
                        list.Add(art);
                    }
                }

                // Assert
                Assert.Equal(4, list.Count);
            }


            /// <summary>
            /// Test to gather the description of an article via meta tags
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherDescription()
            {

                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> { "http://hugogarcia.me/site/testSite1.html" };

                // Act
                var testSite = actualLinks[0];
                string description = "";

                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();
                var html = await httpClient.GetStringAsync(testSite);
                htmlDoc.LoadHtml(html);

                // Associate the proper attributes for the Site. 
                List<string> siteAttribute = siteAttributes.Value;
                // Gather blocks that hold the Description information and store to description.
                var descriptionHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[14]).Where(node => node.GetAttributeValue(siteAttribute[15], "").Equals(siteAttribute[16]));
                foreach (var descriptionString in descriptionHolder)
                {
                    description = descriptionString.GetAttributeValue(siteAttribute[17], "");
                }


                // Assert
                Assert.Equal("This is testSite 1", description);

            }

            /// <summary>
            /// Test to gather the title of an article via meta tags
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherTitle()
            {

                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> { "http://hugogarcia.me/site/testSite1.html" };


                // Act
                var testSite = actualLinks[0];
                string title = "";

                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();
                var html = await httpClient.GetStringAsync(testSite);
                htmlDoc.LoadHtml(html);

                // Associate the proper attributes for the Site. 
                List<string> siteAttribute = siteAttributes.Value;
                // Gather blocks that hold the Title information and store to title.
                var titleHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[10]).Where(node => node.GetAttributeValue(siteAttribute[11], "").Equals(siteAttribute[12]));
                foreach (var titleName in titleHolder)
                {
                    title = titleName.GetAttributeValue(siteAttribute[13], "");
                }


                // Assert
                Assert.Equal("testing testing 1 2 4", title);

            }

            /// <summary>
            /// Test to catch any httprequest exceptions received from a site
            /// </summary>
            /// <returns></returns>
            [Fact]
            public async Task CatchRequestError_Throws_HttpRequestException()
            {
                // Arrange
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("https://techxplore.com/", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" });


                // Act
                var httpClient = new HttpClient();
                Exception e = await Assert.ThrowsAsync<HttpRequestException>(() => httpClient.GetStringAsync(siteAttributes.Key));

                // Assert
                Assert.True(e is HttpRequestException);
            }



        }
    }
}

