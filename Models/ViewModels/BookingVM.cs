using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class BookingVM
    {
        public FlightDetailsVM FlightDetails { get; set; }
        public List<PassengerVM> Passengers { get; set; }
    }
}
