public record AccountState(Guid AccountId)
{
    public int Id { get; set; }

    public string OwnerName { get; set; }

    public decimal Balance { get; set; }

    public string State { get; set; }

    /// <summary>
    /// Version based on LastProcessedEventNumber from account stream
    /// </summary>
    public long Version { get; set; }
}