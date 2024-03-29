﻿using BudgetWpfEf.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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

            var numbers = new List<int> { 1, 2, 3, 4, };
            numbers
                .Where(n => n > 0);

            var planeBudgetInfo = context.BudgetItems
                .Include(b => b.User)
                .Where(b => b.Description.StartsWith("Самолет"))
                .Where(b => b.Id > 2)
                .OrderBy(b => b.Description)
                .Select(b => b.Id);

            planeBudgetInfo.First();

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
