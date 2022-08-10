public record SpendingEvent(decimal Amount) : IEvent
{
    public string Type { get; } = nameof(AccountEventTypes.Spending);
}
