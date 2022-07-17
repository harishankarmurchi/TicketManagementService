using AutoMapper;
using Models.DBModels;
using Models.ViewModels;

namespace TicketManagementService.Configuration
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<FlightDetailsVM, FlightDetail>().ReverseMap();
            CreateMap<PassengerVM, Passenger>().ReverseMap();
            CreateMap<TicketVM, Ticket>().ReverseMap();
            CreateMap<BookingVM, Ticket>().ReverseMap();
        }
    }
}
