using FirstMvcApp.Data;

namespace FirstMvcApp.Services
{
    public interface IBookingSerice
    {
        void BookRoom(Booking booking);

        List<Booking> GetBookings(int userId);
    }
}
