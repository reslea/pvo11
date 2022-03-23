using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tgClone.Models;

namespace tgClone.Repositories
{
    class UserRepository
    {
        private readonly static ObservableCollection<User> Users = new() 
        { 
            new User(1, "user1"),
            new User(2, "user2"),
            new User(3, "user3"),
        };

        public ObservableCollection<User> GetUsers()
        {
            return Users;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
