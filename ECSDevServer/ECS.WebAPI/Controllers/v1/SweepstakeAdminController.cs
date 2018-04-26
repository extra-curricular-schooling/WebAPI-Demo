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
        private readonly ISweepStakeEntryRepository sweepStakeEntryRepository = new SweepStakeEntryRepository();

        private ECSContext db = new ECSContext();

        // USING GET REQUEST TO GET THE VALID SWEEPSTAKES INFORMATION SO THAT A USER CAN BUY TICKETS
        // AND ENTER INTO A SWEEPSTAKE 
        [HttpGet]
        [Route("ValidSweepstakeInfo")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult ValidSweepstakeInfo(SweepstakeAdminDTO sweepstakeValid)
         {
            // CAN MOVE THIS TO SWEEPSTAKE CONTROLLER BECAUSE IT IS SPECIFIC FOR THE SCHOLAR AND SWEEPSTAKE NOT THE ADMIN
            // using the Sweepstake Admin DTO to get data back
                    var answer = db.SweepStakes
                       .Where(x => x.OpenDateTime <= DateTime.Now & x.ClosedDateTime >= DateTime.Now)
                       .FirstOrDefault<SweepStake>();
            if (answer == null)
            {
                return Ok("Sweepstake Not Open");
            }
            else
            {
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
            if (sweepstakeSet.OpenDateTime <= DateTime.Now & sweepstakeSet.ClosedDateTime >= DateTime.Now)
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
            else
            {
                return Ok("Wrong Sweepstakes Dates");
            }
        }

        // REQUEST TO CLOSE SWEEPSTAKE THAT IS SEND OVER BY THE ADMIN
        [HttpGet]
        [Route("CloseSweepstake")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult CloseSweepstake()
        {   
            //IF SENDING DATA OVER THAT IS A POST.
            //IF YOU ARE NOT SENDING DATA OVER THAT IS A GET REQUEST
            var everything = this.sweepStakeEntryRepository.GetAll();
            var winner = everything.Select(x => x.Cost).DefaultIfEmpty(0).Max();
            var nameWinner = sweepStakeEntryRepository.GetSingle(x => x.Cost == winner);
            if (nameWinner == null)
            {
                return Ok("No Winner");
            }
            else
            {
                var wins = nameWinner.UserName;
                SweepStake sweep = sweepStakeRepository.GetSingle(x => x.OpenDateTime <= DateTime.Now & x.ClosedDateTime >= DateTime.Now);
                sweep.UsernameWinner = wins;
                sweepStakeRepository.Update(sweep);
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SweepStakeEntry]");
                return Ok(wins);
            }
        }
    }
}