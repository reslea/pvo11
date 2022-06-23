using Booking.Data.Entities;
using Booking.Services;
using Booking.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(BookingModel model)
        {
            RoomBooking booking = new RoomBooking
            {
                RoomId = model.RoomId,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                VisitorsCount = model.VisitorsCount,
            };

            _service.CreateBooking(booking);

            return Ok();
        }
    }
}
