using ECS.WebAPI.Filters;
using System.Web.Http;
using ECS.WebAPI.Filters.AuthorizationFilters;
using System.Web.Http.Cors;
using ECS.Repositories;
using ECS.Models;
using ECS.DTO;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Threading.Tasks;
using ECS.WebAPI.Filters.AuthenticationFilters;
using System.Collections.Generic;

namespace ECS.WebAPI.Controllers
{

    [RoutePrefix("Home")]
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    public class HomeController : ApiController
    {
        private readonly IArticleRepository articleRepository = new ArticleRepository();
        private readonly IInterestTagRepository interestTagRepository = new InterestTagRepository();
        private readonly IAccountRepository accountRepository = new AccountRepository();

        private ECSContext db = new ECSContext();

        private static readonly Expression<Func<Article, ArticleDTO>> AsArticleDTO = x => new DTO.ArticleDTO
        {
            InterestTag = x.TagName,
            ArticleTitle = x.ArticleTitle,
            ArticleDescription = x.ArticleDescription,
            ArticleLink = x.ArticleLink
        };


        //[AuthenticationRequired]
        [Route("{username}")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public List<IQueryable<ArticleDTO>> GetUserArticles(string username)
        {
            Account account;
            
            List<string> gatheredTags = new List<string>();
            List<IQueryable<ArticleDTO>> list = new List<IQueryable<ArticleDTO>>();
            account = accountRepository.GetSingle(x => x.UserName == username, x => x.AccountTags);


            // TODO: @Hugo Add repository function to perform the 'Include' function below 
            //ECSContext db = new ECSContext();
            foreach (var Tag in account.AccountTags)
                foreach (var tagname in Tag.ArticleTags)
                {

                    if (!gatheredTags.Contains(tagname.TagName))
                    {
                        list.Add(db.Articles.Include(x => x.TagName).Where(x => x.TagName == tagname.TagName).Select(AsArticleDTO));
                        gatheredTags.Add(tagname.TagName);
                    }

                }
            return list;
        }

        //[Route("{username}")]
        //[ResponseType(typeof(List<IQueryable<ArticleDTO>>))]
        //public Task<IHttpActionResult> GetUserArticles(string username)
        //{
        //    Account account;
        //    List<string> gatheredTags = new List<string>();
        //    List<IQueryable<ArticleDTO>> list = new List<IQueryable<ArticleDTO>>();
        //    account = accountRepository.GetSingle(x => x.UserName == username, x => x.AccountTags);
        //    foreach (var Tag in account.AccountTags)
        //        foreach (var tagname in Tag.ArticleTags)
        //        {

        //            if (!gatheredTags.Contains(tagname.TagName))
        //            {
        //                list.Add(db.Articles.Include(x => x.TagName).Where(x => x.TagName == tagname.TagName).Select(AsArticleDTO));
        //                gatheredTags.Add(tagname.TagName);
        //            }

        //        }
        //    return Ok(list);
        //}

        //[Route("")]
        //[ResponseType(typeof(ArticleDTO))]
        //public async Task<IHttpActionResult> GetArticle(string Tag)
        //{
        //    ArticleDTO article = await db.Articles.Include(x => x.ArticleLink).Where(x => x.TagName == Tag).Select(AsArticleDTO).FirstOrDefaultAsync();
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(article);
        //}

    }
}