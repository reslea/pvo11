using System.Data;
using System.Data.SqlClient;

namespace EFClone;

class Program
{
    public static void Main()
    {
        var contextType = typeof(Program).Assembly.GetTypes()
            .First(t => t.BaseType == typeof(DbContext));

        var tableDescriptors = contextType.GetProperties()
            .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(p => new TableDescriptor { Name = p.Name, Type = p.PropertyType.GenericTypeArguments[0] })
            .ToList();

        var budgetInfoDescriptor = tableDescriptors[1];

        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Budgeting;Trusted_Connection=True";
        using var connection = new SqlConnection(connectionString);

        SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"SELECT * FROM {budgetInfoDescriptor.Name}", 
            connection);

        SqlCommandBuilder commandBuilder = new(dataAdapter);

        DataSet dataSet = new();

        dataAdapter.Fill(dataSet);
    }
}

class TableDescriptor
{
    public string Name { get; set; }
    public Type Type { get;  set; }
}