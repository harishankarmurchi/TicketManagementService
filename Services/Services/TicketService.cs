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
        private readonly IMQService _mqService;
        public TicketService(ITicketRepository ticketRepo, IMapper mapper, IApplicationContext context, IMQService mqService)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _context = context;
            _mqService = mqService;
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
                if(result!= null)
                {
                    List<string> seats = new List<string>();
                    foreach (var item in result.Passengers)
                    {
                        seats.Add(item.SeatNo);
                    }
                    var obj = new { FlightId = result.FlightDetail.FlightId, SeatNos = seats, Status = true };
                    _mqService.PublishMessage(obj, "airlineEvent");
                }
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
                if (result != null)
                {
                    List<string> seats = new List<string>();
                    foreach (var item in result.Passengers)
                    {
                        seats.Add(item.SeatNo);
                    }
                    var obj = new { FlightId = result.FlightDetail.FlightId, SeatNos = seats, Status = false };
                    _mqService.PublishMessage(obj, "airlineEvent");
                }
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
        public List<DiscountVM> GetDiscounts()
        {
            try
            {
                var result = _ticketRepo.GetDiscounts();
                return _mapper.Map<List<DiscountVM>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
