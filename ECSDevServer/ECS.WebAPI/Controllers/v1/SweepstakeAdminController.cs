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
using ECS.Constants.Security;

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
        [AuthorizeRequired(ClaimValues.CanEnterRaffle)]
        [HttpGet]
        [Route("ValidSweepstakeInfo")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult ValidSweepstakeInfo(SweepstakeAdminDTO sweepstakeValid)
         {
            // CAN MOVE THIS TO SWEEPSTAKE CONTROLLER BECAUSE IT IS SPECIFIC FOR THE SCHOLAR AND SWEEPSTAKE NOT THE ADMIN
            // using the Sweepstake Admin DTO to get data back
                    var answer = db.SweepStakes
                       .Where(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now)
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
        [AuthorizeRequired(ClaimValues.CanEnterRaffle)]
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
        [AuthorizeRequired(ClaimValues.CanDeleteUser)]
        [HttpPost]
        [Route("SubmitSweepstake/{username}")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult SubmitSweepstake(SweepstakeAdminDTO sweepstakeSet)
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
        [AuthorizeRequired(ClaimValues.CanDeleteUser)]
        [HttpGet]
        [Route("CloseSweepstake")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult CloseSweepstake()
        {
            List<string> sweepstakeEntries = new List<string>();
            var everything = this.sweepStakeEntryRepository.GetAll();
            var sweepstake = db.SweepStakes
                       .Where(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now)
                       .FirstOrDefault<SweepStake>();
            foreach (var entry in everything)
            {
                var entries = (entry.Cost / sweepstake.Price);
                for(int i = 0; i < entries; i++)
                {
                    sweepstakeEntries.Add(entry.Account.UserName);
                }

            }
            Random rnd = new Random();
            int r = rnd.Next(sweepstakeEntries.Count);
            var winner = (string)sweepstakeEntries[r];
            var nameWinner = sweepStakeEntryRepository.GetSingle(x => x.UserName == winner);
            if (nameWinner == null)
            {
                return Ok("No Winner");
            }
            else
            {
                var wins = nameWinner.UserName;
                SweepStake sweep = sweepStakeRepository.GetSingle(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now);
                if (sweep == null)
                {
                    return Ok("No Winner");
                }
                else
                {
                    sweep.UsernameWinner = wins;
                    sweepStakeRepository.Update(sweep);
                    var entries = db.SweepStakeEntries.ToList();
                    foreach (var del in entries)
                    {
                        db.SweepStakeEntries.Remove(del);
                    };
                    db.SaveChanges();
                    return Ok(wins);
                }
            }
        }
    }
}