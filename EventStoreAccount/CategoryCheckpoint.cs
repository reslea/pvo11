namespace EventStoreAccount
{
    public class CategoryCheckpoint
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public long LastProcessedEventNumber { get; set; } = -1;
    }
}