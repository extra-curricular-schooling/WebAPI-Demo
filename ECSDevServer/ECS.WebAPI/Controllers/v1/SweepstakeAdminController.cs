﻿using System.Web.Http;
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

        /// <summary>
        /// Using get request to get the valid sweepstakes information so that a user can buy tickets and enter into a sweepstake.
        /// </summary>
        /// <param name="sweepstakeValid"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This is for the earning points. Need to use PUT to update and POST new user points to the account.
        /// </summary>
        /// <param name="scholarPoints"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Using the POST request for setting sweepstakes in the database. Admin only permissible.
        /// </summary>
        /// <param name="sweepstakeSet"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Request to close sweepstake that is sent over by an Admin.
        /// </summary>
        /// <returns></returns>
        [AuthorizeRequired(ClaimValues.CanDeleteUser)]
        [HttpGet]
        [Route("CloseSweepstake")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult CloseSweepstake()
        {
            try
            {
                List<string> sweepstakeEntries = new List<string>();
                var everything = this.sweepStakeEntryRepository.GetAll();
                if (everything.Count == 0)
                {
                    SweepStake sweepstakeClosed = sweepStakeRepository.GetSingle(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now);
                    var wins = "Closed By Admin";
                    sweepstakeClosed.UsernameWinner = wins;
                    sweepStakeRepository.Update(sweepstakeClosed);
                    return Ok("No Winner");
                }
                else
                {
                    var sweepstake = db.SweepStakes
                               .Where(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now)
                               .FirstOrDefault<SweepStake>();
                    foreach (var entry in everything)
                    {
                        var entries = (entry.Cost / sweepstake.Price);
                        for (int i = 0; i < entries; i++)
                        {
                            sweepstakeEntries.Add(entry.Account.UserName);
                        }

                    }
                    // ALL THE TICKET ENTRIES ARE PUT IN A LIST AND RANDOMLY ONE WINNER CHOSEN
                    Random rnd = new Random();
                    int r = rnd.Next(sweepstakeEntries.Count);
                    var winner = (string)sweepstakeEntries[r];
                    var nameWinner = sweepStakeEntryRepository.GetSingle(x => x.UserName == winner);
                    // GOT THE USERNMAE WHO WON
                    SweepStake sweep = sweepStakeRepository.GetSingle(x => x.UsernameWinner == "No Winner" & x.ClosedDateTime >= DateTime.Now);

                    var wins = nameWinner.UserName;
                    sweep.UsernameWinner = wins;
                    sweepStakeRepository.Update(sweep);
                    var deleteEntries = db.SweepStakeEntries.ToList();

                    // DELETING ALL ENTRIES IN A SWEEPSTAKE ENTRY TABLE

                    foreach (var del in deleteEntries)
                    {
                       db.SweepStakeEntries.Remove(del);
                    };
                    db.SaveChanges();
                    return Ok(wins);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Source + "\n" + e.Message + "\n" + e.InnerException + "\n" + e.StackTrace);
            }
        }
    }
}