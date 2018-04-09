using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{

    [RoutePrefix("v1/Home")]
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