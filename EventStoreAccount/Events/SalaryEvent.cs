public record SalaryEvent(decimal Amount) : IEvent
{
    public string Type { get; } = nameof(AccountEventTypes.Salary);
}
