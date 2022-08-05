using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Abstraction;
using System.Net;

namespace TicketManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("bookticket")]
        [Authorize]
        public Response<TicketVM> BookTicket(BookingVM bookingVM)
        {
            var response = new Response<TicketVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _ticketService.BookTicket(bookingVM);

            }
            catch(Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message=ex.Message;
            }
            return response;
        }
        [HttpGet("getticket/{pnrNo}")]
        [Authorize]
        public Response<TicketVM> GetTicket(int pnrNo)
        {
            var response = new Response<TicketVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _ticketService.GetTicket(pnrNo);

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("getticket")]
        [Authorize]
        public Response<List<TicketVM>> GetTicket()
        {
            var response = new Response<List<TicketVM>>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _ticketService.GetTicketsByUserId();

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete("cancelticket")]
        [Authorize]
        public Response<TicketVM> CancelTicket(long pnrno)
        {
            var response = new Response<TicketVM>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _ticketService.CancelTicket(pnrno);
                response.Message = "ticket cancelled";

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("discount")]
        [Authorize]
        public Response<List<DiscountVM>> getDiscounts(long pnrno)
        {
            var response = new Response<List<DiscountVM>>();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Data = _ticketService.GetDiscounts();
               

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }


    }
}
