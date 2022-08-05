using Models.DBModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface ITicketService
    {
        TicketVM BookTicket(BookingVM bookingVM);
        List<TicketVM> GetTicketsByUserId();
        TicketVM GetTicket(long PnrNo);
        TicketVM CancelTicket(long PnrNo);
        List<DiscountVM> GetDiscounts();
    }
}
