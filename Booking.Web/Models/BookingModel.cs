namespace Booking.Web.Models
{
    public class BookingModel
    {
        public int RoomId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int VisitorsCount { get; set; }
    }
}
