namespace tgClone.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public bool IsChecked { get; set; }
        public Message(int id, string body = null, User sender = null, bool isChecked = false)
        {
            Id = id;
            Body = body;
            Sender = sender;
            SenderId = sender.Id;
            IsChecked = isChecked;
            
        }

    }
}