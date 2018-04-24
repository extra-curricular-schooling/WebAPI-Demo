using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECS.WebCrawler;
namespace ECS.RunCrawler
{

    public class Program
    {
        public static int Main()
        {

            // Art & Design Sitess
            List<KeyValuePair<string, List<string>>> ArtSites = new List<KeyValuePair<string, List<string>>>() { };
             ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));
             ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art/P5", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));
             ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art/P10", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));

            // Does not allow Framing
            // ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.artcyclopedia.com/art-news.php", new List<string> { "font", "size", "+1", "a", "href", "", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));
            // ArtSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/arts", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));
             ArtSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/arts", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));

            // Art & Design Keyword/Tag List
            HashSet<string> ArtTags = new HashSet<string> {"arts", "portrait","portraits", "hollywood","shows","show", "art", "contemporary", "sculpture", "design", "architecture", "paint", "modern", "music", "renaissance", "sustainability", "play", "opera", "gallery", "moma", "abstract", "graphic", "graffiti", "picasso", "da", "vinci", "photography", "model", "portraits" ,"movie","movies","acting","act","actors","actor","fasion","model","modeling","models","music","film","cinema","movie","movies","craft" };


            // Business Sites
            List<KeyValuePair<string, List<string>>> MoneySites = new List<KeyValuePair<string, List<string>>>() { };
            MoneySites.Add(new KeyValuePair<string, List<string>>("https://brokemillennial.com/", new List<string> { "div", "class", "featuredimg", "a", "href", "https://brokemillennial.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Business" }));        
            MoneySites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/business", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Business" }));

            // Business Keyword/Tag List
            HashSet<string> MoneyTags = new HashSet<string> {"marketing","store","stores","goods", "media", "fund", "funds", "securities", "exchange" , "tariff","tariffs",  "data", "credit", "economics", "business", "money", "finances", "stocks", "nasdaq", "dow", "savings", "saving", "bull", "bear", "market", "markets", "bank", "banks", "bankruptcy", "wall", "street", "loan", "loans", "saving", "stock", "quarterly", "anually", "financial", "retire","retirement","finance","refinance","repayment","investment","company","trade" };


            // Environment Sites
            List<KeyValuePair<string, List<string>>> EarthSites = new List<KeyValuePair<string, List<string>>>() { };
            // does not allow framing
            //EarthSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/environment", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));

            EarthSites.Add(new KeyValuePair<string, List<string>>("http://discovermagazine.com/topics/environment", new List<string> { "div", "class", "dataItem", "a", "href", "http://discovermagazine.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));
            EarthSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/green", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));


            // Environment Keyword/Tag List
            HashSet<string> EarthTags = new HashSet<string> { "environment", "environmental", "green", "organic", "sustainability", "smog", "toxic", "peta", "science", "protection", "biology", "conservation", "tree", "trees", "water", "levels", "level", "drought", "rain", "polar", "ice", "glaciers", "epa", "global", "warming","drought","infrastructure","urban","earth","earthquakes","fisheries","fish","animal","ocean","climate","change","industry","global","agriculture","weather","disaster" };

            // Education Sites
            List<KeyValuePair<string, List<string>>> SmartSites = new List<KeyValuePair<string, List<string>>>() { };
            // does not allow framing
            //SmartSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/education", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));


            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.bbc.com/news/education", new List<string> { "div", "class", "pigeon-item__body", "a", "href", "http://www.bbc.com", "meta", "name", "description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.bbc.com/news/education", new List<string> { "div", "class", "sparrow-item__body", "a", "href", "http://www.bbc.com", "meta", "name", "description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "article", "class", "article-popular ", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "div", "class", "copy", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));

            // Education Keyword/Tag List
            HashSet<string> SmartTags = new HashSet<string> {"afford","affordable", "children", "child", "institution", "institutions", "education", "school", "university", "college", "career", "careers", "degree", "masters", "student", "students", "teacher", "teachers", "professor", "professors", "daca", "kindergarten", "developmental", "develop", "science", "stem", "steam", "schools", "colleges", "universities" };

            // History Sites
            List<KeyValuePair<string, List<string>>> AncientSites = new List<KeyValuePair<string, List<string>>>() { };
            AncientSites.Add(new KeyValuePair<string, List<string>>("http://historynewsnetwork.org/", new List<string> { "div", "class", "caption", "a", "href", "https://historynewsnetwork.org", "meta", "property", "og:title", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));
            AncientSites.Add(new KeyValuePair<string, List<string>>("https://www.newhistorian.com/", new List<string> { "div", "class", "news-summary has-feature-image", "a", "href", "https://www.newhistorian.com/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));


            // Doe snot allow framing
            //AncientSites.Add(new KeyValuePair<string, List<string>>("https://www.hoover.org/publications/military-history-news", new List<string> { "h2", "class", "field-title", "a", "href", "https://www.hoover.org", "meta", "name", "description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));

            // History Keyword/Tag List
            HashSet<string> AncientTags = new HashSet<string> { "sculpture","sculptures", "slave", "trade" , "slaves", "trades", "skull", "skulls", "neanderthal", "hominin","hominins", "neanderthals", "history", "ancient", "evolution", "prehistoric", "amazon", "dinosaur", "civil", "mayan", "renaissance", "egypt", "bc", "civil", "rights", "slavery", "battle", "ww1", "ww2", "ww", "war", "wall", "walls", "wars", "foreign", "myth", "norse", "greek", "cave", "neanderthals", "missing", "link", "early", "america", "americas", "native","president","immigrants","presidents","immigrant","society","military","government","war" };

            // Medical Sites
            List<KeyValuePair<string, List<string>>> MedicalSites = new List<KeyValuePair<string, List<string>>>() { };
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "featured", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Medical" }));
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "knowledge", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Medical" }));
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "written", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Medical" }));

            // Medical Keyword/Tag List
            HashSet<string> MedicalTags = new HashSet<string> {"remedy", "remedies", "condition", "conditions", "symptom","symptoms","medication", "medications","body", "immune","cells","cell","immunity", "pandemic", "virus", "software", "medicine", "cancer", "research", "health", "medical", "healthy", "blood", "diabetes", "chemotherapy", "chemo", "advancements", "advancement", "pills", "pharmaceutical", "pharma", "pharmaceuticals", "opiod", "habit", "addiction", "pain", "tocix", "diet", "benefits", "benefit","smoke","smoking","study","studies","cell","dna","suicide","depression","mental" };

            // Technology Sites
            List<KeyValuePair<string, List<string>>> TechSites = new List<KeyValuePair<string, List<string>>>() { };

            // does not allow framing
            //TechSites.Add(new KeyValuePair<string, List<string>>("http://news.mit.edu/topic/computers", new List<string> { "h3", "class", "title", "a", "href", "http://news.mit.edu", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            //TechSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/topics/computer-science-6612", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));



            TechSites.Add(new KeyValuePair<string, List<string>>("http://discovermagazine.com/topics/technology", new List<string> { "div", "class", "dataItem", "a", "href", "http://discovermagazine.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/topic/computer-science", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "article", "class", "article-popular ", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "div", "class", "copy", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));


            // Technology Keyword/Tag List
            HashSet<string> TechTags = new HashSet<string> {"robot","robots","bionic","drone","drones","drive", "drives", "usb", "data", "software", "technologies", "technology","computer", "computers", "google", "apps", "apple", "amazon", "microsoft", "ai", "elon musk", "spacex", "nasa","intelligence","internet","engineer","engineering","development","programming","code","program","coding","science","intelligent","research","study","studies","stem" };

            // Art & Design Crawler
            ICrawler artie = new BaseCrawler(ArtSites, ArtTags);

            // Business Crawler
            ICrawler cachingie = new BaseCrawler(MoneySites, MoneyTags);

            // Environmental Crawler
            ICrawler earthie = new BaseCrawler(EarthSites, EarthTags);

            // Education Crawler
            ICrawler smartie = new BaseCrawler(SmartSites, SmartTags);

            // History Crawler
            ICrawler oldie = new BaseCrawler(AncientSites, AncientTags);

            // Medical Crawler
            ICrawler medie = new BaseCrawler(MedicalSites, MedicalTags);

            // Tech Crawler
            ICrawler techie = new BaseCrawler(TechSites, TechTags);

            // Run all crawlers asynchronously but waits until they are complete before moving on.
            try
            {
                Task.WaitAll(artie.CrawlingAsync(), cachingie.CrawlingAsync(), earthie.CrawlingAsync(), smartie.CrawlingAsync(), oldie.CrawlingAsync(), medie.CrawlingAsync(), techie.CrawlingAsync());
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine(DateTime.Now + e.Task.ToString()+": "+ e.Message);
            }
            
            Console.WriteLine(DateTime.Now + ": Crawler Ended");
            return 0;
        }
    }
}
