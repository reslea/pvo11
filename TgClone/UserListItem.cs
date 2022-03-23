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
    public partial class UserListItem : UserControl
    {
        public UserListItem()
        {
            InitializeComponent();
        }

        public UserListItem(User user)
        {
            InitializeComponent();
            NicknameLabel.Text = user.Nickname;
        }

        internal object ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
