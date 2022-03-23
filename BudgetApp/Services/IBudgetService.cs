using BudgetApp.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BudgetApp.Services
{
    public interface IBudgetService
    {
        public SortType SortType { get; set; }

        decimal GetTotalPrice();

        ObservableCollection<BudgetInfo> GetBudgetInfos();

        void AddBudgetInfo(BudgetInfo info);
    }
}