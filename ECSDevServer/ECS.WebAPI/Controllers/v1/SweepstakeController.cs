using System.Web.Http;
using ECS.Models;
using ECS.DTO;
using System.Web.Http.Cors;
using ECS.Constants.Network;
using ECS.Repositories.Implementations;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/Sweepstake")]
    //[AuthorizeRequired("canEnterRaffle", Roles = "Scholar")]
    public class SweepstakeController : ApiController
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly ISweepStakeEntryRepository sweepStakeEntryRepository = new SweepStakeEntryRepository();
        private readonly ISweepStakeRepository sweepStakeRepository = new SweepStakeRepository();

        private ECSContext db = new ECSContext();

        // REQUEST TO GET THE POINTS ASSOCIATED WITH A SCHOLAR ACCOUNT
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
        // REQUEST TO POST A TICKET FOR A SWEEPSTAKE
        [HttpPost]
        [Route("ScholarTicket/{username}")]
        [EnableCors(origins: CorsConstants.BaseAcceptedOrigins, headers: CorsConstants.BaseAcceptedHeaders, methods: "POST")]
        public IHttpActionResult submitSweepstake(SweepStakeEntryDTO sweepstakeUser)
        {
            // CHECKING IF THE USER ALREADY HAS A TICKET IN THE SWEEPSTAKE
            // ADD TICKET IF NOT
            // OTHERWISE ADD ANOTHER COST TO IT
            // THE USER WITH THE HIGHEST "POINTS LEFT" AFTER BUYING A SWEEPSTAKE WINS
            Account account;
            account = accountRepository.GetSingle(x => x.UserName == sweepstakeUser.UserName);
            var updatedPoints = sweepstakeUser.UpdatedPoints;
            account.Points = updatedPoints;
            accountRepository.Update(account);


            SweepStakeEntry checkUser;
            checkUser = sweepStakeEntryRepository.GetSingle(x => x.UserName == sweepstakeUser.UserName);

            if (checkUser.UserName != sweepstakeUser.UserName)
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
             /*   var newCost = sweepstakeUser.Cost * 2;
                sweepstakeUser.Cost = newCost;
                SweepStakeEntry sweep = new SweepStakeEntry()
                {
                    SweepstakesID = sweepstakeUser.SweepstakesID,
                    OpenDateTime = sweepstakeUser.OpenDateTime,
                    PurchaseDateTime = sweepstakeUser.PurchaseDateTime,
                    Cost = sweepstakeUser.Cost,
                    UserName = sweepstakeUser.UserName,
                };
                
                sweepStakeEntryRepository.Update(sweep); */
                return Ok("Another Ticket NOT Added");
            } 
        }
        
    }
}