using Booking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public interface IBookingService
    {
        void CreateBooking(RoomBooking booking);

        void AddBookingDetails(BookingDetails details);
    }
}
