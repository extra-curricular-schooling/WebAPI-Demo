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

    /// <summary>
    /// Controller for home page
    /// </summary>
    [RoutePrefix("v1/Home")]
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    public class HomeController : ApiController
    {
        /// <summary>
        /// Repository objects
        /// </summary>
        private readonly IAccountRepository accountRepository = new AccountRepository();

        /// <summary>
        /// Instantiate DB context to acquire all articles based of all the interest tags of a single user.
        /// </summary>
        private ECSContext db = new ECSContext();

        /// <summary>
        /// Instantiate Article DTO
        /// </summary>
        private static readonly Expression<Func<Article, ArticleDTO>> AsArticleDTO = x => new DTO.ArticleDTO
        {
            InterestTag = x.TagName,
            ArticleTitle = x.ArticleTitle,
            ArticleDescription = x.ArticleDescription,
            ArticleLink = x.ArticleLink
        };


        /// <summary>
        /// Controller to gather the articles of a user based on their interest tags.
        /// </summary>
        /// <param name="username"></param>
        /// <returns> A list of articleDTO</returns>
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

    }
}