public record InitialEvent(decimal Amount, string Username, Guid AccountNumber) 
    : IEvent
{
    public string Type { get; } = nameof(AccountEventTypes.Initial);
}
