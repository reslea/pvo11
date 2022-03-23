using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tgClone.Models;

namespace tgClone
{
    public partial class MessageListItem : UserControl
    {

        public MessageListItem()
        {
            InitializeComponent();
        }
        public MessageListItem(Models.Message message, bool isFromCurrentUser = false)
        {
            InitializeComponent();
                MessageLabel.Text = message.Body;
                NicknameLabel.Text = message.Sender.Nickname;
            if (!isFromCurrentUser)
            {
                NicknameLabel.Dock = DockStyle.Left;
                MessageLabel.Dock = DockStyle.Fill;
            }
            
        }
    }
}
