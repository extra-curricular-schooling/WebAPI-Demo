using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DTO
{
    public class SweepstakeAdminDTO
    {
        public DateTime OpenDateTime { get; set; }

        public DateTime ClosedDateTime { get; set; }

        public string Prize { get; set; }

        public string UsernameWinner { get; set; }

        public int SweepStakesID { get; set; }
    }
}
