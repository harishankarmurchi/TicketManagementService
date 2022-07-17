using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class FlightDetailsVM
    {
        public string FlightNumber { get; set; }
        public int FlightId { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public double TotalCost { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
