namespace Booking.Services.Hubs
{
    public interface IBookingClient
    {
        Task RoomBooked(string bookingJson);
    }
}
