using BudgetApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        private ObservableCollection<BudgetInfo> budgetInfos = new();

        public SortType SortType { get; set; } = SortType.Descending;


        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }


        public void AddBudgetInfo(BudgetInfo info)
        {
            _budgetRepository.Add(info);
            if (SortType == SortType.Descending)
            {
                budgetInfos.Insert(0, info);
            }
            else
            {
                budgetInfos.Add(info);
            }
        }

        public ObservableCollection<BudgetInfo> GetBudgetInfos()
        {
            var shouldDownload = budgetInfos.Count == 0;
            if (shouldDownload)
            {
                foreach (var budgetInfo in _budgetRepository.Get(SortType))
                {
                    budgetInfos.Add(budgetInfo);
                }
            }

            return budgetInfos;
        }

        public decimal GetTotalPrice()
        {
            return budgetInfos.Sum(bi => bi.Amount);
        }
    }
}
