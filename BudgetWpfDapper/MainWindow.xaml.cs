using DapperClone;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace BudgetWpfDapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var connection = new SqlConnection(
                           ConfigurationManager
                               .ConnectionStrings["BudgetingDb"]
                               .ConnectionString);

            var searchBudgetItems1 = connection.Query<BudgetInfo>(
                "SELECT * FROM BudgetItems WHERE Id BETWEEN @IdMin AND @IdMax",
                new { IdMin = 1, IdMax = 2000 });

            searchBudgetItems1.First();

            BudgetDataGrid.ItemsSource = searchBudgetItems1;
        }
    }
}
