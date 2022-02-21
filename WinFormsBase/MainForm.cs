using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WinFormsBase
{
    public partial class MainForm : Form
    {
        private Action onClickAction;

        public MainForm()
        {
            InitializeComponent();

            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            var server = @"(localdb)\MSSQLLocalDB";
            var database = "People";

            var connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            await Task.Delay(1000);
            
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";
            using var reader = command.ExecuteReader();

            var usersTable = new DataTable();

            bool isFirstTime = true;
            
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
            
            await Task.Delay(1000);
            UsersGridView.DataSource = usersTable;
        }

        private async void ClickMeBtn_Click(object? sender, EventArgs e)
        {

        }
    }
}