using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
        public bool IsOptedForMeal { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
