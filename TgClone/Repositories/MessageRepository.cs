using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tgClone.Models;

namespace tgClone.Repositories
{
    class MessageRepository
    {
        private readonly static ObservableCollection<Message> Messages = new() {};
        public ObservableCollection<Message> GetMessages()
        {
            return Messages;
        }

        internal void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}
