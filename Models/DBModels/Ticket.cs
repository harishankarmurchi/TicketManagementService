using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public long PnrNo { get; set; }
        public int UserId { get; set; }
        public int NoOfSeats { get; set; }

        public bool IsCancelled { get; set; }

        public int FlightDetailId { get; set; }
        public FlightDetail FlightDetail { get; set; }

        public List<Passenger> Passengers { get; set; }

    }
}
