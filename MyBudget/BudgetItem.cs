namespace MyBudget
{
    public class BudgetItem
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public BudgetItem(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}