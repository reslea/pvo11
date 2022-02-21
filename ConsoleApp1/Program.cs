using System.Data;
using System.Data.SqlClient;

var server = @"(localdb)\MSSQLLocalDB";
var database = "People";

var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
SqlConnection connection = new SqlConnection(connectionString);

Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
await Task.Delay(1000);
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
await connection.OpenAsync();

var command = connection.CreateCommand();
command.CommandText = "SELECT * FROM Users";
using var reader = command.ExecuteReader();

var usersTable = new DataTable();

bool isFirstTime = true;
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
while (await reader.ReadAsync())
{
    if (isFirstTime)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            string columnName = reader.GetName(i);
            Type columnType = reader.GetFieldType(i);
            usersTable.Columns.Add(columnName, columnType);
        }
        isFirstTime = false;
    }

    DataRow row = usersTable.NewRow();

    for (int i = 0; i < reader.FieldCount; i++)
    {
        row.SetField(i, reader.GetValue(i));
    }

    usersTable.Rows.Add(row);
}
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
await Task.Delay(1000);
