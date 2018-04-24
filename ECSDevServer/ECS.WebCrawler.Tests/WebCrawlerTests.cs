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
using ECS.Repositories.Implementations;
using ECS.Models;
using ECS.Repositories.Contracts;

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
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                Sites.Add(new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" }));
                List<string[]> actualLinks = new List<string[]> {
                    new string[] {"http://hugogarcia.me/site/testSite1.html", "http://hugogarcia.me/site/testing.html"},
                    new string[] {"http://www.hugogarcia.me/site/testSite2.html", "http://hugogarcia.me/site/testing.html" },
                    new string[] {"http://hugogarcia.me/site/testSite3.html" , "http://hugogarcia.me/site/testing.html"},
                    new string[] {"http://hugogarcia.me/site/testSite4.html", "http://hugogarcia.me/site/testing.html" },
                    new string[] {"http://hugogarcia.me/site/testSite5.html" , "http://hugogarcia.me/site/testing.html" }
                };
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                BaseCrawler test = new BaseCrawler(Sites, Tags);

                // Act
                var result = await test.GatherArticles(Sites);

                // Assert
                Assert.Equal(actualLinks, result);
            }


            /// <summary>
            /// Test to gather the tags from an article via the meta tag
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherTags()
            {

                // Arrange
                
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                string links =  "http://hugogarcia.me/site/testSite1.html" ;
                BaseCrawler test = new BaseCrawler(Sites, null);
                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();
                var html = await httpClient.GetStringAsync(links);
                htmlDoc.LoadHtml(html);

                string[] actualTags = { "test", "", "testing", "", "tester", "", "blah", "", "bla", "", "foo", "", "bar" };

                string[] contentTags = { };

                // Act
                contentTags = test.GatherTags(htmlDoc, siteAttributes.Value);

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
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                BaseCrawler test = new BaseCrawler(Sites, Tags);
                // Act
                bool tagMatch = test.MatchTags(contentTags);


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
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                BaseCrawler test = new BaseCrawler(Sites, Tags);
                // Act
                bool tagMatch = test.MatchTags(contentTags);

                // Assert
                Assert.False(tagMatch);
                
            }


            /// <summary>
            /// Test to add accepted articles to a list
            /// </summary>
            [Fact]
            public async void ArticleCrawler_AcceptArticles()
            {
                var tag = new InterestTag
                {
                    TagName = "Testing",
                    AccountUsername = null,
                    ArticleTags = null
                };

                var mockInterestRepo = new Mock<IInterestTagRepository>();
                mockInterestRepo.Setup(x => x.Insert(tag));
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                Sites.Add(new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" }));
                // KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                HashSet<string> Tags = new HashSet<string> { "hm", "test", "tester" };

                BaseCrawler test = new BaseCrawler(Sites, Tags);

                // Act
                var result = await test.GatherArticles(Sites);
                var list = await test.ArticleCrawler(result);

                // Assert
                Assert.Equal(4, list.Count);
            }


            /// <summary>
            /// Test to gather the description of an article via meta tags
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherDescription()
            {

                // Assert
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                string links = "http://hugogarcia.me/site/testSite1.html";
                BaseCrawler test = new BaseCrawler(Sites, null);
                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();
                var html = await httpClient.GetStringAsync(links);
                htmlDoc.LoadHtml(html);


                // Act
                string description = test.GatherDescription(htmlDoc, siteAttributes.Value);



                // Assert
                Assert.Equal("This is testSite 1", description);

            }

            /// <summary>
            /// Test to gather the title of an article via meta tags
            /// </summary>
            [Fact]
            public async void ArticleCrawler_GatherTitle()
            {

                // Assert
                List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
                KeyValuePair<string, List<string>> siteAttributes = new KeyValuePair<string, List<string>>("http://hugogarcia.me/site/testing.html", new List<string> { "div", "class", "test", "a", "href", "http://hugogarcia.me/site/", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "name", "description", "content", "Testing" });
                string links = "http://hugogarcia.me/site/testSite1.html";
                BaseCrawler test = new BaseCrawler(Sites, null);
                var httpClient = new HttpClient();
                var htmlDoc = new HtmlDocument();
                var html = await httpClient.GetStringAsync(links);
                htmlDoc.LoadHtml(html);


                // Act
                string title = test.GatherTitle(htmlDoc, siteAttributes.Value);


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

