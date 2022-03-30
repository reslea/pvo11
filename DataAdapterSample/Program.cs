using System.Data;
using System.Data.SqlClient;

var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Budgeting;Trusted_Connection=True";
using var connection = new SqlConnection(connectionString);

SqlDataAdapter dataAdapter = GetDataAdapter(connection);

SqlCommandBuilder commandBuilder = new(dataAdapter);

DataSet budgetingDataSet = new();

dataAdapter.Fill(budgetingDataSet);

DataTable table = budgetingDataSet.Tables["Table"];

// INSERT
var row = table.NewRow();
row.ItemArray = new object[] { null, 123, "Test" };
table.Rows.Add(row);

// UPDATE
table.Rows[0].ItemArray = new object[] { 1, 15, "!!!" };

// DELETE
table.Rows[4].Delete();

for (int i = 0; i < table.Rows.Count; i++)
{
    var tableRow = table.Rows[i];

    Console.WriteLine($"{i}: {tableRow.RowState}");
}

//dataAdapter.Update(budgetingDataSet);

Console.WriteLine();

static SqlDataAdapter GetDataAdapter(SqlConnection connection)
{
    SqlDataAdapter dataAdapter = new("SELECT * FROM BudgetItems", connection);

    //dataAdapter.InsertCommand = GetInsertCommand(connection);
    //dataAdapter.UpdateCommand = GetUpdateCommand(connection);
    //dataAdapter.DeleteCommand = GetDeleteCommand(connection);
    return dataAdapter;
}

static SqlCommand GetInsertCommand(SqlConnection connection)
{
    var insertCommand = new SqlCommand(
            "INSERT INTO BudgetItems (Amount, Description) VALUES (@Amount, @Description)",
            connection);
    insertCommand.Parameters.Add("@Amount", SqlDbType.Decimal, 8, "Amount");
    insertCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000, "Description");
    return insertCommand;
}

static SqlCommand GetUpdateCommand(SqlConnection connection)
{
    var updateCommand = new SqlCommand(
        "UPDATE BudgetItems SET Amount = @Amount, Description = @Description WHERE Id = @Id",
        connection);
    updateCommand.Parameters.Add("@Amount", SqlDbType.Decimal, 8, "Amount");
    updateCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000, "Description");
    updateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
    return updateCommand;
}

static SqlCommand GetDeleteCommand(SqlConnection connection)
{
    var deleteCommand = new SqlCommand(
        "DELETE FROM BudgetItems WHERE Id = @Id",
        connection);
    deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
    return deleteCommand;
}