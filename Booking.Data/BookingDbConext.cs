using Booking.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class BookingDbConext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Booking;Integrated Security=True;";
            options.UseSqlServer(connectionString);
        }
    }
}