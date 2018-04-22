using System.Web.Http;
using ECS.Models;
using ECS.DTO;
using ECS.Repositories;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ECS.Repositories.Implementations;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sweepstake")]
    //[AuthorizeRequired("canEnterRaffle", Roles = "Scholar")]
    public class SweepstakeController : ApiController
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly ISweepStakeEntryRepository sweepStakeEntryRepository = new SweepStakeEntryRepository();
        private ECSContext db = new ECSContext();

        // REQUEST TO GET THE POINTS ASSOCIATED WITH A SCHOLAR ACCOUNT
        [HttpGet]
        [Route("ScholarPoints/{username}")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "GET")]
        public IHttpActionResult ScholarInformation(string username)
        {
            Account account;
            account = accountRepository.GetSingle(x => x.UserName == username);
            var points = account.Points;
            return Ok(points);
        
        }
        /*
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
        public IHttpActionResult submitSweepstake(SweepStakeEntryDTO sweepstakeUser)
        {
            //Account account;
            //account = _account.GetSingle(x => x.UserName == UserName);

            SweepStakeEntry sweep = new SweepStakeEntry()
            {
                SweepstakesID = sweepstakeUser.SweepstakesID,
                OpenDateTime = sweepstakeUser.OpenDateTime,
                PurchaseDateTime = sweepstakeUser.PurchaseDateTime,
                Cost = sweepstakeUser.Cost,
                UserName = sweepstakeUser.UserName,
            };
            _sweepStakeEntryRepository.Insert(sweep);
            return Ok("Post Sweepstake Ticket");
        }
        */
    }
}