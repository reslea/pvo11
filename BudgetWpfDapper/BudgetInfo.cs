namespace BudgetWpfDapper
{
    public class BudgetInfo
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public BudgetInfo() { }

        public BudgetInfo(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
        }

        public BudgetInfo(int id, decimal amount, string description)
        {
            Id = id;
            Amount = amount;
            Description = description;
        }
    }
}
