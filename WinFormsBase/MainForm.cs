using System.Data;
using System.Data.SqlClient;

namespace WinFormsBase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DownloadData();
        }

        private void DownloadData()
        {
            var server = @"(localdb)\MSSQLLocalDB";
            var database = "People";

            var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";
            using var reader = command.ExecuteReader();

            var usersTable = new DataTable();

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

            UsersGridView.DataSource = usersTable;
        }
    }
}