using System.Data.SqlClient;

namespace AdoBasics
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SqlConnection connection;

        public UsersRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int InsertUser(User user)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                $"INSERT INTO Users (Name, Age) VALUES (@name, @age)";
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("age", user.Age);

            var affectedRows = command.ExecuteNonQuery();
            return affectedRows;
        }

        public IEnumerable<User> GetUsers()
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                $"SELECT * FROM Users";


            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                //var userProps = typeof(User).GetProperties();
                //var user = new User();
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    userProps[i].SetValue(user, reader.GetValue(i));
                ////    userProps[i].SetValue(user, reader[i]);
                //}

                int id = reader.GetFieldValue<int>(0);
                string name = reader.GetFieldValue<string>(1);
                int age = reader.GetFieldValue<int>(2);

                var user = new User(id, name, age);

                yield return user;
            }
        }

        public int UpdateUser(User user)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                $"UPDATE Users " +
                $"SET Name = @name, Age = @age " +
                $"WHERE Id = @id";

            command.Parameters.AddWithValue("id", user.Id);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("age", user.Age);

            var affectedRows = command.ExecuteNonQuery();
            return affectedRows;
        }

        public int DeleteUser(int userId)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                $"DELETE FROM Users WHERE Id = @id";

            command.Parameters.AddWithValue("id", userId);

            var affectedRows = command.ExecuteNonQuery();
            return affectedRows;
        }
    }
}
