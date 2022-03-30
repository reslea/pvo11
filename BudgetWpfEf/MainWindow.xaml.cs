using BudgetWpfEf.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BudgetWpfEf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            using var context = new BudgetContext();

            context.Database.EnsureCreated();

            LoadBudgetData(context);
        }

        private void AddBudgetInfo_Click(object sender, RoutedEventArgs e)
        {
            using var context = new BudgetContext();

            var budgetAmount = int.Parse(BudgetAmount.Text);
            var newItem = new BudgetInfo
            {
                Amount = budgetAmount,
                Description = BudgetDescription.Text,
            };

            context.BudgetItems.Add(newItem);

            //var planeBudgetInfo = context.BudgetItems
            //    .FirstOrDefault(b => b.Description.StartsWith("Самолет"));

            //planeBudgetInfo.Amount = 20_000;

            context.SaveChanges();

            LoadBudgetData(context);
        }

        private void LoadBudgetData(BudgetContext context)
        {
            var budgetData = context.BudgetItems.ToList();

            BudgetInfoDataGrid.ItemsSource = budgetData;
        }
    }
}
