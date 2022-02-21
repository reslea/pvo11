using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tgClone.Models;

namespace tgClone.Repositories
{
    class ChatRepository
    {
        private readonly static List<Chat> Chats = new()
        {
            new Chat(1, new List<User>(), new List<Message>()),
            new Chat(2, new List<User>(), new List<Message>()),
            new Chat(3, new List<User>(), new List<Message>()),
        };

        public List<Chat> GetChats()
        {
            return Chats;
        }
    }
}
