using Microsoft.Extensions.DependencyInjection;
using MyBudget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex numbersRegex = new("[^0-9-]+", RegexOptions.Compiled);
        private readonly IBudgetRepository _budgetRepository;
        private decimal _totalBalance;
        private ObservableCollection<BudgetInfo> budgetInfos = new();
        
        public MainWindow()
        {
            IServiceProvider serviceProvider = SetupDependencyInjection();

            _budgetRepository = serviceProvider.GetService<IBudgetRepository>();

            InitializeComponent();
            InitializeGrid();
            InitializeBudgetData();
        }

        private void BudgetInfos_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            TotalBalanceInfo.Text = budgetInfos.Sum(b => b.Amount).ToString();
        }

        private static IServiceProvider SetupDependencyInjection()
        {
            ServiceCollection serviceDescriptors = new();
            serviceDescriptors
                .AddSingleton<IBudgetRepository, BudgetRepository>()
                .AddSingleton(new SqlConnection(
                        ConfigurationManager
                            .ConnectionStrings["BudgetingDb"]
                            .ConnectionString));

            return serviceDescriptors.BuildServiceProvider();
        }

        private void InitializeGrid()
        {
            //BudgetGrid.Columns.Add(new DataGridTextColumn()
            //{
            //    Header = "Amount",
            //    Binding = new Binding(nameof(BudgetInfo.Amount)),
            //});
            //BudgetGrid.Columns.Add(new DataGridTextColumn()
            //{
            //    Header = "Description",
            //    Binding = new Binding(nameof(BudgetInfo.Description)),
            //});
        }

        private void InitializeBudgetData()
        {
            budgetInfos.CollectionChanged += BudgetInfos_CollectionChanged;
            foreach (var budgetInfo in _budgetRepository.Get())
            {
                budgetInfos.Add(budgetInfo);
            }

            BudgetGrid.ItemsSource = budgetInfos;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var budgetInfo = new BudgetInfo(
                decimal.Parse(BudgetAmountTextBox.Text),
                BudgetDescriptionTextBox.Text);
            try
            {
                _budgetRepository.Add(budgetInfo);
                budgetInfos.Add(budgetInfo);
            }
            catch
            {
                MessageBox.Show(
                    "Oops, cannot save", 
                    "", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        private void BudgetAmountTextBox_ValidateOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = numbersRegex.IsMatch(e.Text);
        }
    }
}
