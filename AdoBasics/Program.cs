using System.Data.SqlClient;

var server = @"(localdb)\MSSQLLocalDB";
var database = "People";

var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    var name = Console.ReadLine();
    var age = 20;

    SqlCommand command = InsertUser(connection, name, age);

    Console.WriteLine(command.CommandText);

    var affectedRows = command.ExecuteNonQuery();

    Console.WriteLine($"affected rows: {affectedRows}");
}

SqlCommand InsertUser(SqlConnection connection, string name, int age)
{
    SqlCommand command = connection.CreateCommand();

    command.CommandText =
        $"INSERT INTO Users (Name, Age) VALUES (@name, @age)";
    command.Parameters.AddWithValue("name", name);
    command.Parameters.AddWithValue("age", age);

    return command;
}