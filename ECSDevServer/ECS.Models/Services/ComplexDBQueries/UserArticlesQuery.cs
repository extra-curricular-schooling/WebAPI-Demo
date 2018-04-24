using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ECS.DTO;
using ECS.Models;

namespace ECS.BusinessLogic.Services.ComplexDBQueries
{
    public class UserArticlesQuery
    {
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

        public List<IQueryable<ArticleDTO>> RetrieveUserArticles(Account account)
        {
            List<string> gatheredTags = new List<string>();
            List<IQueryable<ArticleDTO>> list = new List<IQueryable<ArticleDTO>>();
            foreach (var Tag in account.AccountTags)
            {
                foreach (var tagname in Tag.ArticleTags)
                {

                    if (!gatheredTags.Contains(tagname.TagName))
                    {
                        list.Add(db.Articles.Include(x => x.TagName).Where(x => x.TagName == tagname.TagName).Select(AsArticleDTO));
                        gatheredTags.Add(tagname.TagName);
                    }

                }
            }
            return list;
            
        }
    }
}
