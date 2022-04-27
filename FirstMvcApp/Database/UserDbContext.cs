﻿using Microsoft.EntityFrameworkCore;

namespace FirstMvcApp.Database;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=User;Trusted_Connection=True";
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
