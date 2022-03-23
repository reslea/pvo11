using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tgClone.Models;
using tgClone.Repositories;

namespace tgClone
{
    
    public partial class MainForm : Form
    {
        private static Random Random = new();
        private const int currentUserId = 1;
        private UserRepository userRepository = new();
        private MessageRepository messageRepository = new();
        public MainForm()
        {
            InitializeComponent();
            InitializeUsersPanel();
            InitializeMessagesPanel();
        }

        
        private void InitializeMessagesPanel()
        {
            var messages = messageRepository.GetMessages();

            MessagesPanel.Controls.AddRange(messages
                .Select(m => new MessageListItem(m) { Dock = DockStyle.Bottom })
                .ToArray());

            messages.CollectionChanged += Messages_CollectionChanged;
        }

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                MessagesPanel.Controls.AddRange(e.NewItems
                    ?.Cast<Models.Message>()
                    .Select(m => new MessageListItem(m, m.Sender.Id==currentUserId) { Dock = DockStyle.Bottom })
                    .ToArray()
                    );
            }
        }

        private void InitializeUsersPanel()
        {
            var users = userRepository.GetUsers();

            UsersPanel.Controls.AddRange(users
                .Select(u => new UserListItem(u) { Dock = DockStyle.Top })
                .ToArray());

            users.CollectionChanged += Users_CollectionChanged;
        }

        private void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                UsersPanel.Controls.AddRange(e.NewItems
                    ?.Cast<User>()
                    .Select(u => new UserListItem(u) { Dock = DockStyle.Top })
                    .ToArray()
                    );
            }
        }
        static int userCounter = 3;
        private void UserAddTimer_Tick(object sender, EventArgs e)
        {           
           if (userCounter <= 7)
            {
                userRepository.AddUser(new User(++userCounter, $"user{userCounter}"));
            }
        }

        static int messageCounter = 0;
        private void MessageAddTimer_Tick(object sender, EventArgs e)
        {
            var users = userRepository.GetUsers();
            var userIndex = Random.Next(0, users.Count);
            
            var message = new Models.Message(
                ++messageCounter, 
                messageCounter.ToString(),
                users[userIndex]);

            messageRepository.AddMessage(message);
        }
    }
}
