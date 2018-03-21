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

        public class Article
        {
            public string ArticleTitle { get; set; }
            public string ArticleLink { get; set; }
            public string ArticleDescription { get; set; }
            public string TagName { get; set; }
        }




        public class HomeCrawler
        {

            [Fact]
            public async void HomeCrawler_ReturnHTMLString()
            {
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });



                TestSite testSite = new TestSite();
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(siteAttributes.Key);



                Assert.Equal(testSite.SiteHtml, html);

            }

            [Fact]
            public async void HomeCrawler_LoadHTMLBlocks()
            {
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> attributes = siteAttributes.Value;


                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(siteAttributes.Key);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();



                Assert.Equal(5, blocks.Count);

            }

            [Fact]
            public async void HomeCrawler_GatherArticles()
            {
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> {
                    "http://hugogarcia.me/site/testSite1.html",
                    "http://www.hugogarcia.me/site/testSite2.html",
                    "http://hugogarcia.me/site/testSite3.html",
                    "http://hugogarcia.me/site/testSite4.html",
                    "http://hugogarcia.me/site/testSite5.html"
                };

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



                Assert.Equal(actualLinks, links);
            }


            /// TODO: @Hugo Finish tests.
            [Fact]
            public void ArticleCrawler_GatherTags()
            {

            }
            [Fact]
            public async void CheckArticleTags()
            {
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
                Assert.Equal(4, list.Count);
            }

            [Fact]
            public async void ReturnArticleDescription()
            {
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> {
                    "http://hugogarcia.me/site/testSite1.html",
                    "http://www.hugogarcia.me/site/testSite2.html",
                    "http://hugogarcia.me/site/testSite3.html",
                    "http://hugogarcia.me/site/testSite4.html",
                    "http://hugogarcia.me/site/testSite5.html"
                };

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

                Assert.Equal("This is testSite 1", description);

            }

            [Fact]
            public async void ReturnArticleTitle()
            {
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                List<string> actualLinks = new List<string> {
                    "http://hugogarcia.me/site/testSite1.html",
                    "http://www.hugogarcia.me/site/testSite2.html",
                    "http://hugogarcia.me/site/testSite3.html",
                    "http://hugogarcia.me/site/testSite4.html",
                    "http://hugogarcia.me/site/testSite5.html"
                };


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

                Assert.Equal("testing testing 1 2 4", title);

            }

            [Fact]
            public async Task CatchRequestError_Throws_HttpRequestException()
            {

                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("https://techxplore.com/", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" });


                var httpClient = new HttpClient();
                Exception e = await Assert.ThrowsAsync<HttpRequestException>(() => httpClient.GetStringAsync(siteAttributes.Key));


                Assert.True(e is HttpRequestException);
            }



        }
    }
}

