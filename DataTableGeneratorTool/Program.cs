using System.Data;


var dataSet = DataTableGenerator.GenerateDataSet(typeof(User), typeof(Movie));

var userTable = dataSet.Tables["User"]!;
var movieTable = dataSet.Tables["Movie"]!;

var userRow = userTable.NewRow();
userRow["Name"] = "Alex";
userRow["Age"] = "33";
userTable.Rows.Add(userRow);

var movieRow = movieTable.NewRow();
movieRow["Title"] = "Wandering";
movieRow["UserId"] = "3";
movieTable.Rows.Add(movieRow);

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Movie
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    [ForeignKey("User.Id")]
    public int UserId { get; set; }
}

class DataTableGenerator
{
    public static DataSet GenerateDataSet(params Type[] tableTypes)
    {
        var result = new DataSet();

        foreach (var type in tableTypes)
        {
            var table = new DataTable(type.Name);
            result.Tables.Add(table);

            GenerateTable(table, type);
        }

        return result;
    }

    public static DataTable GenerateTable(DataTable table, Type tableType)
    {
        var tableProperties = tableType.GetProperties();

        foreach (var property in tableProperties)
        {
            var name = property.Name;
            var type = property.PropertyType;

            bool isBuiltInType = type.IsPrimitive
                || type == typeof(string)
                || type == typeof(DateTime);

            if (!isBuiltInType)
            {
                throw new ArgumentException("Cannot generate table with complex types");
            }

            var column = new DataColumn(name, type);
            table.Columns.Add(column);

            if (property.CustomAttributes.Any(c => c.AttributeType == typeof(KeyAttribute)))
            {
                column.AutoIncrement = true;
                column.AutoIncrementSeed = 1000;
                column.AutoIncrementStep = 1;
                column.AllowDBNull = false;
                column.Unique = true;
                continue;
            }
        }

        return table;
    }
}