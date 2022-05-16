using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcApp.Data
{
    public class Booking
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int VisitorsCount { get; set; }
    }
}
