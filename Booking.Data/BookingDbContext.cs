﻿using Booking.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomBooking> RoomBookings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookingDetails> BookingDetails { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Booking;Integrated Security=True;";
        //    options.UseSqlServer(connectionString);
        //}
    }
}