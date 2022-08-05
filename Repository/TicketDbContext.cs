using Microsoft.EntityFrameworkCore;
using Models.DBModels;

namespace Repository
{
    public class TicketDbContext:DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options):base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightDetail> FlightDetails { get; set; }

        public DbSet<Discount> Discount { get; set; }

    }
}