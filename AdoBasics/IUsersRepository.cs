using System.Data.SqlClient;

namespace AdoBasics
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();

        int InsertUser(User user);

        int UpdateUser(User user);

        int DeleteUser(int userId);
    }
}