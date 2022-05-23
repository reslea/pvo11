using FirstMvcApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstMvcApp.Database;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=User;Trusted_Connection=True";
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasData(new List<Room>
        {
            new() { Id = 1, Name = "for 5 people", MaxVisitorsCount = 5 },
            new() { Id = 2, Name = "for 3 people cheap", MaxVisitorsCount = 3 },
            new() { Id = 3, Name = "for 1 people luxury", MaxVisitorsCount = 1 }
        });

        modelBuilder.Entity<Role>()
            .HasData(new List<Role>
            {
                new() { Id = 1, Name = "User" },
                new() { Id = 2, Name = "Admin" },
            });

        modelBuilder.Entity<User>()
            .HasData(new List<User>
            {
                new() { Id = 1, Age = 20, Name = "Admin", RoleId = 2, Password = "admin", Email = "admin@gmail.com", Created = DateTime.Now },
                new() { Id = 2, Age = 20, Name = "User", RoleId = 1, Password = "user", Email = "user@gmail.com", Created = DateTime.Now }
            });

        base.OnModelCreating(modelBuilder);
    }
}
