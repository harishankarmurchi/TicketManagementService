using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class TicketVM
    {
        public long PnrNo { get; set; }
        public int NoOfSeats { get; set; }
        public bool IsCancelled { get; set; }

        public FlightDetailsVM FlightDetail { get; set; }
        public List<PassengerVM> Passengers { get; set; }
    }
}
