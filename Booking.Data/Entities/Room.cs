using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxVisitorsCount { get; set; }
    }
}
