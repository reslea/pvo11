using BudgetApp;
using System.Collections.Generic;
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

        public void Add(BudgetInfo budgetItem)
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                "INSERT INTO BudgetItems (Amount, Description)" +
                $"VALUES (@amount, @description)";
            command.Parameters.AddWithValue("amount", budgetItem.Amount);
            command.Parameters.AddWithValue("description", budgetItem.Description);

            command.ExecuteNonQuery();
        }

        public List<BudgetInfo> Get()
        {
            List<BudgetInfo> result = new();

            var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM BudgetItems";
            using var reader = command.ExecuteReader();

            while(reader.Read())
            {
                var amount = reader.GetFieldValue<decimal>(1);
                var description = reader.GetFieldValue<string>(2);

                result.Add(new BudgetInfo(amount, description));
            }

            return result;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}