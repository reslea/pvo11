using System.Data;
using System.Reflection;

namespace DapperClone
{
    public static class DbConnectionExtentions
    {
        private static Dictionary<string, List<PropertyInfo>> QueryCache = new();

        public static IEnumerable<T> Query<T>(
            this IDbConnection connection,
            string queryString,
            object? parameters = null)
            where T : new()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using IDataReader reader = GetDataReader(connection, queryString, parameters);

            List<PropertyInfo> propertiesToFill;

            if (!QueryCache.TryGetValue(queryString, out propertiesToFill))
            {
                propertiesToFill = GetPropertiesToFill<T>(reader);

                QueryCache.Add(queryString, propertiesToFill);
            }

            while (reader.Read())
            {
                var obj = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var fieldValue = reader.GetValue(i);
                    propertiesToFill[i].SetValue(obj, fieldValue);
                }

                yield return obj;
            }
        }

        private static List<PropertyInfo> GetPropertiesToFill<T>(IDataReader reader) where T : new()
        {
            var properties = typeof(T).GetProperties();

            var propertiesToFill = new List<PropertyInfo>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var fieldName = reader.GetName(i);

                var prop = properties.First(p => p.Name.Equals(fieldName));
                propertiesToFill.Add(prop);
            }

            return propertiesToFill;
        }

        private static IDataReader GetDataReader(IDbConnection connection, string queryString, object? parameters)
        {
            var command = connection.CreateCommand();
            command.CommandText = queryString;

            if (parameters is not null)
            {
                var properties = parameters.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var param = command.CreateParameter();
                    param.ParameterName = property.Name;
                    param.Value = property.GetValue(parameters);

                    command.Parameters.Add(param);
                }
            }

            var reader = command.ExecuteReader();
            return reader;
        }
    }
}