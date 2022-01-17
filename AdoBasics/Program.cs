using AdoBasics;
using System.Data.SqlClient;

var server = @"(localdb)\MSSQLLocalDB";
var database = "People";

var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    IUsersRepository usersRepo = new UsersRepository(connection);

    GetUsers(usersRepo);
    DeleteUser(usersRepo);
    GetUsers(usersRepo);
}

void InsertNewUser(IUsersRepository usersRepo)
{
    Console.WriteLine("enter a name for new user:");
    var name = Console.ReadLine();
    var age = 20;

    usersRepo.InsertUser(new User(name, age));
}

void GetUsers(IUsersRepository usersRepo)
{
    var users = usersRepo.GetUsers();

    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}:\t{user.Name}\t{user.Age}");
    }
}

void UpdateUser(IUsersRepository usersRepo)
{
    var user = new User(1002, "Andy", 10);

    usersRepo.UpdateUser(user);
}

void DeleteUser(IUsersRepository usersRepo)
{
    usersRepo.DeleteUser(1002);
}