using System.Data;
using System.Data.SqlClient;

var server = @"(localdb)\MSSQLLocalDB";
var database = "People";

var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Users";
    using var reader = command.ExecuteReader();

    DataTable usersTable = new DataTable();

    bool isFirstTime = true;
    while (reader.Read())
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

    foreach (DataRow row in usersTable.Rows)
    {
        foreach (var col in row.ItemArray)
        {
            Console.Write($"{col}\t");
        }
        Console.WriteLine();
    }
}