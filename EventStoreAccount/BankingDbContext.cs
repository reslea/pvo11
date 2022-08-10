using Microsoft.EntityFrameworkCore;

namespace EventStoreAccount
{
    public class BankingDbContext : DbContext
    {
        public DbSet<AccountState> AccountStates { get; set; }

        public DbSet<CategoryCheckpoint> CategoryCheckpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankDb;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
