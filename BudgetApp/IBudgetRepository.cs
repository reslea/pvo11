using BudgetApp;
using System;
using System.Collections.Generic;

namespace MyBudget
{
    public interface IBudgetRepository : IDisposable
    {
        void Add(BudgetInfo budgetItem);

        List<BudgetInfo> Get();
    }
}