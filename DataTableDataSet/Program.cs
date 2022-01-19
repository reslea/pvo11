using System.Data;
using System.Data.SqlClient;

var server = @"(localdb)\MSSQLLocalDB";
var database = "People";

var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";

using (var connection = new SqlConnection(connectionString))
{
    // users table
    DataTable usersTable = new DataTable();

    DataColumn idCol = usersTable.Columns.Add("Id", typeof(int));

    idCol.AutoIncrement = true;
    idCol.AutoIncrementSeed = 1000;
    idCol.AutoIncrementStep = 1;
    idCol.AllowDBNull = false;
    idCol.Unique = true;

    DataColumn userCol = usersTable.Columns.Add("Name", typeof(string));

    userCol.AllowDBNull = false;
    userCol.Unique = true;

    DataColumn ageCol = usersTable.Columns.Add("Age", typeof(int));

    ageCol.AllowDBNull = false;


    // movie table
    DataTable movieTable = new DataTable();

    DataColumn movieIdCol = movieTable.Columns.Add("Id", typeof(int));
    movieIdCol.AutoIncrement = true;
    movieIdCol.AutoIncrementSeed = 1000;
    movieIdCol.AutoIncrementStep = 1;
    movieIdCol.AllowDBNull = false;
    movieIdCol.Unique = true;

    DataColumn movieTitleCol = movieTable.Columns.Add("Title", typeof(string));
    movieTitleCol.AllowDBNull = false;
    movieTitleCol.Unique = true;

    DataColumn userIdCol = movieTable.Columns.Add("UserId", typeof(int));
    userIdCol.AllowDBNull = false;
    userIdCol.Unique = true;

    // data set
    DataSet movieData = new DataSet();
    movieData.Tables.Add(usersTable);
    movieData.Tables.Add(movieTable);

    movieData.Relations.Add("movie_userId", idCol, userIdCol);

    DataRow row1 = usersTable.NewRow();
    row1[userCol] = "Alex";
    row1[ageCol] = "33";

    usersTable.Rows.Add(row1);

    DataRow row2 = usersTable.NewRow();
    row2[userCol] = "Alexandra";
    row2[ageCol] = 33;

    usersTable.Rows.Add(row2);

    DataRow movie1 = movieTable.NewRow();
    movie1[movieTitleCol] = "Wandering";
    movie1[userIdCol] = 1;

    movieTable.Rows.Add(movie1);


    //connection.Open();

    //var command = connection.CreateCommand();
    //command.CommandText = "SELECT * FROM Users";
    //using var reader = command.ExecuteReader();


    //bool isFirstTime = true;
    //while (reader.Read())
    //{
    //    if (isFirstTime)
    //    {
    //        for (int i = 0; i < reader.FieldCount; i++)
    //        {
    //            string columnName = reader.GetName(i);
    //            Type columnType = reader.GetFieldType(i);
    //            usersTable.Columns.Add(columnName, columnType);
    //        }
    //        isFirstTime = false;
    //    }

    //    DataRow row = usersTable.NewRow();

    //    for (int i = 0; i < reader.FieldCount; i++)
    //    {
    //        row.SetField(i, reader.GetValue(i));
    //    }

    //    usersTable.Rows.Add(row);
    //}

    foreach (DataRow rowData in movieTable.Rows)
    {
        foreach (var col in rowData.ItemArray)
        {
            Console.Write($"{col}\t");
        }
        Console.WriteLine();
    }
}