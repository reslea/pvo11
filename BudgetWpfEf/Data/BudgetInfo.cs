namespace BudgetWpfEf.Data;

public class BudgetInfo
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
