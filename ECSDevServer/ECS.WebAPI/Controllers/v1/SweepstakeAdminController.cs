using System.Web.Http;
using System.Web.Http.Cors;
using ECS.Models;
using ECS.Repositories.Implementations;
using ECS.DTO;

namespace ECS.WebAPI.Controllers.v1
{
    [RoutePrefix("v1/SweepstakeAdmin")]
    public class SweepstakeAdminController : ApiController
    {
        private AccountRepository account;
        private readonly ISweepStakeRepository sweepStakeRepository;
        public SweepstakeAdminController()
        {
            account = new AccountRepository();
            sweepStakeRepository = new SweepStakeRepository();
        }

        /// <summary>
        /// Retrieve a scholar's points after knowing the username
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ScholarPoints/{username}")]
        [EnableCors("http://localhost:8080", "*", "GET")]
        public IHttpActionResult ScholarPoints(string username)
        {
            // Look at the account repo and search for person's points.

            // Return Point object.
            return Ok("Get Scholar Points");
        }

        /// <summary>
        /// Modifying a Scholar's points, use a put.
        /// </summary>
        /// <returns></returns>

        // We need to prevent the admin for blasting this with updates.
        [HttpPost]
        [Route("ScholarPoints")]
        [EnableCors("http://localhost:8080", "*", "POST")]
        public IHttpActionResult ScholarPoints(Account account)
        {
            // Check model binding

            // Update points in database.

            // Return successful response if update correctly.
            return Ok("Post Scholar Points");
        }
        [HttpPost]
        [Route("submitSweepstake")]
        //[EnableCors("http://localhost:8080", "*", "POST")]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "POST")]
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