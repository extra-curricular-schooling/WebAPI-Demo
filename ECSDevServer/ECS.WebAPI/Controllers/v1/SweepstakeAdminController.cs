using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ECS.Constants.Network;
using ECS.WebAPI.Filters.AuthorizationFilters;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/SweepstakeAdmin")]
    public class SweepstakeAdminController : ApiController
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly ISweepStakeRepository sweepStakeRepository = new SweepStakeRepository();
        
        private ECSContext db = new ECSContext();

        // USING GET REQUEST TO GET THE VALID SWEEPSTAKES INFORMATION SO THAT A USER CAN BUY TICKETS
        // AND ENTER INTO A SWEEPSTAKE 
        [HttpGet]
        [Route("ValidSweepstakeInfo")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult ValidSweepstakeInfo(SweepstakeAdminDTO sweepstakeValid)
         {// using the Sweepstake Admin DtO to get data back
                    var answer = db.SweepStakes
                       .Where(x => x.OpenDateTime <= DateTime.Now & x.ClosedDateTime >= DateTime.Now)
                       .FirstOrDefault<SweepStake>();

            SweepstakeAdminDTO sweepstake = new SweepstakeAdminDTO()
            {
                SweepStakesID = answer.SweepStakesID,
                OpenDateTime = answer.OpenDateTime,
                ClosedDateTime = answer.ClosedDateTime,
                Prize = answer.Prize,
                UsernameWinner = answer.UsernameWinner,
                Price = answer.Price,

            };
            return Ok(sweepstake);
         }

        // THIS IS FOR THE EARNING POINTS
        // NEED TO USE PUT OR WELL LETS JUST SAY UPDATE IN ORDER TO MODIFY AND POST NEW USER POINTS TO THE ACCOUNT
        [HttpPost]
        [Route("UpdatePoints/{username}")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult UpdatePoints(ScholarPointsDTO scholarPoints)
        {
            Account account = accountRepository.GetSingle(x => x.UserName == scholarPoints.ScholarUserName);
            var pointsOld = account.Points;
            // till here i have the points in the user accounts that is in our case ZERO
            var pointsNew = pointsOld + scholarPoints.Points;
            // TILL HERE ADDED THE POINTS THAT ARE RECIEVED FROM THE FRONT END.

            //Now POST pointsNew to the username or associated account.
            account.Points = pointsNew;
            accountRepository.Update(account);
            return Ok("Post Scholar Updated Points");
        }

        // USING THE POST REQUEST FOR POSTING/SETTING SWEEPSTAKES TO THE DATABASE BY ADMIN ONLY
        [HttpPost]
        [Route("submitSweepstake")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult submitSweepstake(SweepstakeAdminDTO sweepstakeSet)
        {
            SweepStake sweep = new SweepStake()
            {
                SweepStakesID = sweepstakeSet.SweepStakesID,
                OpenDateTime = sweepstakeSet.OpenDateTime,
                ClosedDateTime = sweepstakeSet.ClosedDateTime,
                Prize = sweepstakeSet.Prize,
                UsernameWinner = sweepstakeSet.UsernameWinner,
                Price = sweepstakeSet.Price,
            };
            sweepStakeRepository.Insert(sweep);
            return Ok("Post Sweepstake by Admin");
        }
    }
}