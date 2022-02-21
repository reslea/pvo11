using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyBudget
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();

            var serviceProvider = serviceCollection
                .AddSingleton<IBudgetRepository, BudgetRepository>()
                .AddSingleton<MyBudgetForm>()
                .AddSingleton<SqlConnection>((_) => 
                    new SqlConnection(ConfigurationManager
                        .ConnectionStrings["BudgetingDb"]
                        .ConnectionString))
                
                .BuildServiceProvider();

            var form = serviceProvider.GetService<MyBudgetForm>();

            Application.Run(form);
        }
    }
}