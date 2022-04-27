using Microsoft.EntityFrameworkCore;

public class StoreContext : DbContext
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Store;Trusted_Connection=True";

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Shipment> Shipment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}