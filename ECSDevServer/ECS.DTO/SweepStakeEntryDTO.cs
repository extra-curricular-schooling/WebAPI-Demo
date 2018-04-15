using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.DTO
{
    public class SweepStakeEntryDTO
    {
        public DateTime PurchaseDateTime { get; set; }

        public string UserName { get; set; }

        public int Cost { get; set; }

        public DateTime OpenDateTime { get; set; }

        public int SweepstakesID { get; set; }

        //public List<SweepstakeAdminDTO> SweepStakeEntry { get; set; }


        //   public int Points { get; set; }

    }
}
