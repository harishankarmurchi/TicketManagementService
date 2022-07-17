using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PassengerVM
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
        public bool IsOptedForMeal { get; set; }
    }
}
