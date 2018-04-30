using System.Web.Http;
using ECS.Models;
using ECS.DTO;
using System.Web.Http.Cors;
using ECS.Constants.Network;
using ECS.Repositories.Implementations;
using ECS.WebAPI.Filters.AuthorizationFilters;
using ECS.Constants.Security;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sweepstake")]
    public class SweepstakeController : ApiController
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly ISweepStakeEntryRepository sweepStakeEntryRepository = new SweepStakeEntryRepository();
        private readonly ISweepStakeRepository sweepStakeRepository = new SweepStakeRepository();

        private ECSContext db = new ECSContext();

        /// <summary>
        /// GET request for points associated with a single scholar account.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [AuthorizeRequired(ClaimValues.CanEnterRaffle)]
        [HttpGet]
        [Route("ScholarPoints/{username}")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "GET")]
        public IHttpActionResult ScholarInformation(string username)
        {
            Account account;
            account = accountRepository.GetSingle(x => x.UserName == username);
            var points = account.Points;
            return Ok(points);
        
        }

        /// <summary>
        /// POST request for a single purchased ticket in a given sweepstake.
        /// </summary>
        /// <param name="sweepstakeUser"></param>
        /// <returns></returns>
        [AuthorizeRequired(ClaimValues.CanEnterRaffle)]
        [HttpPost]
        [Route("ScholarTicket/{username}")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult submitSweepstake(SweepStakeEntryDTO sweepstakeUser)
        {
            // CHECKING IF THE USER ALREADY HAS A TICKET IN THE SWEEPSTAKE
            // ADD TICKET IF NOT
            // OTHERWISE ADD ANOTHER COST TO IT
            // THE USER WITH THE HIGHEST "COST" (POINTS SPENT ON TICKETS) WINS A SWEEPSTAKE
            Account account;
            account = accountRepository.GetSingle(x => x.UserName == sweepstakeUser.UserName);
            var updatedPoints = sweepstakeUser.UpdatedPoints;
            account.Points = updatedPoints;
            accountRepository.Update(account);


            SweepStakeEntry checkUser;
            checkUser = sweepStakeEntryRepository.GetSingle(x => x.UserName == sweepstakeUser.UserName);
            if (checkUser == null)
            {
               SweepStakeEntry sweep = new SweepStakeEntry()
                {
                    SweepstakesID = sweepstakeUser.SweepstakesID,
                    OpenDateTime = sweepstakeUser.OpenDateTime,
                    PurchaseDateTime = sweepstakeUser.PurchaseDateTime,
                    Cost = sweepstakeUser.Cost,
                    UserName = sweepstakeUser.UserName,
                };
                sweepStakeEntryRepository.Insert(sweep);
                return Ok("Post Sweepstake Ticket");
            }
            else
            {
                // GETTING THE OLD COST IN THE TABLE
                var oldCost = checkUser.Cost;
                // GETTING THE NEW COST SEND OVER AND ADDING IT TO THE OLD
                var newCost = sweepstakeUser.Cost + oldCost;
                checkUser.Cost = newCost;
                // UPDATING THE COST
                sweepStakeEntryRepository.Update(checkUser);

                return Ok("Another Ticket Added");
            } 
        }
        
    }
}