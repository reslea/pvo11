using System;
using System.Collections.Generic;

namespace BudgetApp.Data
{
    public interface IBudgetRepository : IDisposable
    {
        void Add(BudgetInfo budgetItem);

        List<BudgetInfo> Get(SortType sortType = SortType.Descending);
    }
}