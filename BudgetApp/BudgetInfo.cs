namespace BudgetApp
{
    public class BudgetInfo
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public BudgetInfo(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}
