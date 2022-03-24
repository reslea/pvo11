using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BudgetWpfEf.Data;

internal class BudgetContext : DbContext
{
    public DbSet<BudgetInfo> BudgetItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["BudgetingDb"].ConnectionString;

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}
