using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ECS.DTO;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.WebAPI.Filters.AuthorizationFilters;
using Xunit;
using ECS.WebAPI.Controllers.v1;

namespace ECS.WebAPI.Tests.Controllers
{
    public class HomeControllerTests
    {
        //private static readonly Expression<Func<Article, ArticleDTO>> AsArticleDTO = x => new DTO.ArticleDTO
        //{
        //    InterestTag = x.TagName,
        //    ArticleTitle = x.ArticleTitle,
        //    ArticleDescription = x.ArticleDescription,
        //    ArticleLink = x.ArticleLink
        //};
        //private readonly IAccountRepository accountRepository = new AccountRepository();
        //private ECSContext db = new ECSContext();

        //[Theory]
        //[InlineData("test2")]
        //public void GetUserArticles(string username)
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

        //        Assert.True(list != null);

        // }


    }
}
