using FirstMvcApp.Data;
using FirstMvcApp.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FirstMvcApp.Services;

public class BookingService : IBookingSerice
{
    private readonly UserDbContext _context;

    public BookingService(UserDbContext context)
    {
        _context = context;
    }

    public void BookRoom(Booking booking)
    {
        if (booking.DateFrom >= booking.DateTo)
        {
            throw new ValidationException($"DateFrom shoud be lower than DateTo");
        }

        var isRoomBookedExpression = IsRoomBookedExpr(booking);

        var existingBookings = _context.Bookings
            .Where(b => b.RoomId == booking.RoomId)
            .Where(isRoomBookedExpression);

        if (existingBookings.Any())
        {
            throw new BookingUnavailableException("These dates are already booked by another user");
        }

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        static Expression<Func<Booking, bool>> IsRoomBookedExpr(Booking booking)
        {
            return b =>
                (booking.DateFrom > b.DateFrom && b.DateTo < booking.DateTo && b.DateTo > booking.DateFrom &&
                b.DateFrom < booking.DateTo)
                ||
                (b.DateFrom > booking.DateFrom && b.DateTo > booking.DateTo && b.DateTo > booking.DateFrom &&
                b.DateFrom < booking.DateTo)
                ||
                (b.DateFrom < booking.DateFrom && b.DateTo > booking.DateTo && b.DateFrom < booking.DateTo &&
                b.DateTo > booking.DateFrom)
                ||
                (b.DateFrom > booking.DateFrom && b.DateTo < booking.DateTo && b.DateFrom < booking.DateTo &&
                b.DateTo > booking.DateFrom);
        }
    }

    public List<Booking> GetBookings(int userId)
    {
        return _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Where(b => b.UserId == userId)
            .ToList();
    }
}
