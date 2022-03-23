using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgClone.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        public User(int id = 0, string nickname = null)
        {
            Id = id;
            Nickname = nickname;
        }
    }
}
