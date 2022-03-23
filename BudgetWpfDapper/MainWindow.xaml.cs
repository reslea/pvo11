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

            var searchBudgetItems2 = connection.Query<BudgetInfo>(
                "SELECT * FROM BudgetItems WHERE Id BETWEEN @IdMin AND @IdMax",
                new { IdMin = 1, IdMax = 2000 });

            searchBudgetItems2.First();

            var searchBudgetItems3 = connection.Query<BudgetInfo>(
                "SELECT * FROM BudgetItems WHERE Id BETWEEN @IdMin AND @IdMax",
                new { IdMin = 1, IdMax = 2000 });

            searchBudgetItems3.First();

            var searchBudgetItems4 = connection.Query<BudgetInfo>(
                "SELECT * FROM BudgetItems WHERE Id BETWEEN @IdMin AND @IdMax",
                new { IdMin = 1, IdMax = 2000 });

            searchBudgetItems4.First();

            BudgetDataGrid.ItemsSource = searchBudgetItems4;
        }
    }
}
