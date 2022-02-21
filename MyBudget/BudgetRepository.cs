using System.Data.SqlClient;

namespace MyBudget
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly SqlConnection _connection;

        public BudgetRepository(SqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public void Add(BudgetItem budgetItem)
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                "INSERT INTO BudgetItems (Amount, Description)" +
                $"VALUES (@amount, @description)";
            command.Parameters.AddWithValue("amount", budgetItem.Amount);
            command.Parameters.AddWithValue("description", budgetItem.Description);

            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}