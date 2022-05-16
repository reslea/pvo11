using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models
{
    public class AddBookingModel
    {
        public int RoomId { get; set; }

        [Range(1, 5)]
        public int VisitorsCount { get; set; }

        public DateTime DateFrom { get; set; } // todo: add validation for date

        public DateTime DateTo { get; set; } // todo: add validation for date
    }
}
