using FirstMvcApp.Data;
using FirstMvcApp.Helpers;
using FirstMvcApp.Models;
using FirstMvcApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FirstMvcApp.Models
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingSerice _service;
        private readonly ClaimsWrapper _claimsWrapper;

        public BookingController(IBookingSerice service, ClaimsWrapper claimsWrapper)
        {
            _service = service;
            _claimsWrapper = claimsWrapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int userId = _claimsWrapper.UserId!.Value;

            List<Booking> bookings = _service.GetBookings(userId);

            return View(bookings);
        }

        [HttpGet]
        public IActionResult Book(int roomId)
        {
            return View(new AddBookingModel { RoomId = roomId });
        }

        [HttpPost]
        public IActionResult Book(AddBookingModel model)
        {
            int userId = _claimsWrapper.UserId!.Value;

            try
            {
                _service.BookRoom(new Booking
                {
                    RoomId = model.RoomId,
                    UserId = userId,
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo,
                    VisitorsCount = model.VisitorsCount,
                });

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(nameof(AddBookingModel.DateFrom), ex.Message);
                return View(model);
            }
            //catch (BookingUnavailableException ex)
            //{
            //    ModelState.AddModelError(nameof(AddBookingModel.DateFrom), ex.Message);
            //    return View(model);
            //}
        }
    }
}
