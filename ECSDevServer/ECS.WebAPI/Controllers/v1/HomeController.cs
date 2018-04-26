using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Cors;
using ECS.BusinessLogic.ControllerLogic.Implementations;
using ECS.BusinessLogic.Services.ComplexDBQueries;
using ECS.Constants.Network;
using ECS.Constants.Security;
using ECS.DTO;
using ECS.Models;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{

    /// <summary>
    /// Controller for home page
    /// </summary>
    [RoutePrefix("v1/Home")]
    // Had to make a custom filter for RequireHttpsAttribute
    [RequireHttps]
    [AuthorizeRequired(ClaimValues.CanEditInformation)]
    public class HomeController : ApiController
    {
        /// <summary>
        /// HomeControllerLogic to acquire account
        /// </summary>
        HomeControllerLogic controllerLogic = new HomeControllerLogic();
        /// <summary>
        /// UserArticlesQuery to perform the service of accessing data through a linq more complex than the repo can handle
        /// </summary>
        UserArticlesQuery userArticlesQuery = new UserArticlesQuery();

        /// <summary>
        /// Controller to gather the articles of a user based on their interest tags.
        /// </summary>
        /// <param name="username"></param>
        /// <returns> A list of articleDTO</returns>
        [HttpGet]
        [Route("{username}/GetUserArticles")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public List<IQueryable<ArticleDTO>> GetUserArticles(string username)
        {

            Account account = controllerLogic.accountLogic.IncludeAccountTags(username);
            return userArticlesQuery.RetrieveUserArticles(account);

        }

    }
}