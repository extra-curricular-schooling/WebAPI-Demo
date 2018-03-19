
namespace ECS.WebCrawler.Tests
{
    public class TestSite
    {
        public string SiteHtml { get; set; }
        public TestSite()
        {
            SiteHtml = "<!DOCTYPE html>\r\n\r\n<html lang=\"en\">\r\n    <head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>Hugo's Website</title>\r\n		<link rel=\"stylesheet\" href=\"../css/home.css\">\r\n        <script src=\"./js/iframe.js\"></script>\r\n	</head>\r\n	<body>\r\n		<div class=\"container\" id=\"topcontainer\">\r\n			<header>Hugo Garcia</header>\r\n			<div class=\"topnav\" id=\"mynav\">\r\n				<a href = \"../index.html\">Home</a>\r\n				<a href = \"#about\">About Me</a>\r\n				<a href = \"resume.html\">Resume</a>\r\n				<a href = \"https://github.com/hugogarcia354\" title=\"Redirects to my Github\">My Projects</a>\r\n				<a href = \"social_media.html\">Social Media</a>\r\n				<a href = \"contact.html\">Contact</a>\r\n			</div>	\r\n		</div>\r\n		<div class=\"test\">\r\n			<a href=\"testSite1.html\">TestSite1</a>\r\n		</div>\r\n		<div class=\"test\">\r\n				<a href=\"http://www.hugogarcia.me/site/testSite2.html\">TestSite2</a>\r\n		</div>\r\n		<div class=\"test\">\r\n			<a href=\"testSite3.html\">TestSite3</a>\r\n		</div>\r\n		<div class=\"test\">\r\n			<a href=\"testSite4.html\">TestSite4</a>\r\n		</div>\r\n		<div class=\"test\">\r\n			<a href=\"testSite5.html\">TestSite5</a>\r\n		</div>\r\n         <iframe id =\"resultFrame\"src=\"http://money.cnn.com/2017/09/08/technology/business/carriers-hurricanes/index.html\" height=\"700\" width=\"100%\"></iframe> \r\n    </body>\r\n</html>\r\n";
        }
    }
}