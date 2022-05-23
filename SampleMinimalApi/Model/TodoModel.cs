namespace SampleMinimalApi.Model
{
    public class TodoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDone { get; set; }
    }
}
