public record ClosedEvent() : IEvent 
{
    public string Type { get; } = nameof(AccountEventTypes.Closed);
}