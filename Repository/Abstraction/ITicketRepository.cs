using Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface ITicketRepository
    {
        Ticket CreateTicket(Ticket ticket);
        List<Ticket> GetTicketByUserId(int userId);
        Ticket GetTicketByPNR(long PNR);
        Ticket CancelTicket(long pnrno);
        List<Discount> GetDiscounts();
    }
}
