namespace Booking.Data.Entities
{
    public class BookingDetails
    {
        public int Id { get; set; }

        public int BoookingId { get; set; }

        public RoomBooking Booking { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public DateTime? LeaveDate { get; set; }
    }
}
