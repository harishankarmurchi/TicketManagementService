using Microsoft.EntityFrameworkCore;
using Models.DBModels;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class TicketRepository: ITicketRepository
    {
        public readonly TicketDbContext _dbContext;
        public TicketRepository(TicketDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            try
            {
                _dbContext.Add(ticket);
                _dbContext.SaveChanges();
                return ticket;

            }catch(Exception ex)
            {
                throw;
            }
        }

        public List<Ticket> GetTicketByUserId(int userId)
        {
            try
            {
                return _dbContext.Tickets.Include("FlightDetail").Include("Passengers")
                    .Where(x=> x.UserId== userId).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Ticket GetTicketByPNR(long PNR)
        {
            try
            {
                var res= _dbContext.Tickets.Include("FlightDetail").Include("Passengers")
                    .FirstOrDefault(x => x.PnrNo == PNR);
                return res;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Ticket CancelTicket(long pnrno)
        {
            try
            {
               var res= _dbContext.Tickets.Include("FlightDetail").Include("Passengers").FirstOrDefault(x => x.PnrNo == pnrno);
                res.IsCancelled = true;
                _dbContext.Update(res);
                _dbContext.SaveChanges();
                return res;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public List<Discount> GetDiscounts()
        {
            try
            {
                return _dbContext.Discount.ToList();

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
