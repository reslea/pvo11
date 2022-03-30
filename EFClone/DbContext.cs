namespace EFClone
{
    public abstract class DbContext
    {

    }

    public class DbSet<T>
    {

    }

    public class BudgetContext : DbContext
    {
        public DbSet<BudgetInfo> BudgetItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}