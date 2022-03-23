using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgClone.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public List<User> Users { get; set; } = new();
        public List<Message> Messages { get; set; } = new();

        public Chat(int id, List<User> users = null, List<Message> messages = null)
        {
            Id = id;
            Users = users;
            Messages = messages;
        }

    }
}
