using AutoMapper;
using Models.DBModels;
using Models.ViewModels;
using Repository.Abstraction;
using Services.Abstraction;
using Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly IMapper _mapper;
        private readonly IApplicationContext _context;
        public TicketService(ITicketRepository ticketRepo, IMapper mapper, IApplicationContext context)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _context = context;
        }
    
        public TicketVM BookTicket(BookingVM bookingVM)
        {
            try
            {
                var ticket = new Ticket();
                ticket.FlightDetail = _mapper.Map<FlightDetail>(bookingVM.FlightDetails);
                ticket.Passengers = _mapper.Map<List<Passenger>>(bookingVM.Passengers);
                ticket.UserId = _context.UserId;
                ticket.NoOfSeats = ticket.Passengers.Count();
                var random = new Random();
                ticket.PnrNo = random.NextInt64(1000000, 9999999);
                var result = _ticketRepo.CreateTicket(ticket);
                return _mapper.Map<TicketVM>(result);
            }catch(Exception ex)
            {
                throw;
            }


        }

        public TicketVM CancelTicket(long PnrNo)
        {
            try
            {
                var result = _ticketRepo.CancelTicket(PnrNo);
                return _mapper.Map<TicketVM>(result);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public TicketVM GetTicket(long PnrNo)
        {
            try
            {
                var result = _ticketRepo.GetTicketByPNR(PnrNo);
                return _mapper.Map<TicketVM>(result);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public List<TicketVM> GetTicketsByUserId()
        {
            try
            {
                var result = _ticketRepo.GetTicketByUserId(_context.UserId);
                return _mapper.Map<List<TicketVM>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
