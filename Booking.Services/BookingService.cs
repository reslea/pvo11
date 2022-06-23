using Booking.Data;
using Booking.Data.Entities;

namespace Booking.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext context;

        public BookingService(BookingDbContext context)
        {
            this.context = context;
        }

        public void CreateBooking(RoomBooking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }
    }
}
