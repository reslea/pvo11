namespace MyBudget
{
    public interface IBudgetRepository : IDisposable
    {
        void Add(BudgetItem budgetItem);
    }
}