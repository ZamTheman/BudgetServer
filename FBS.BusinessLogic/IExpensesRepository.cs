using System;
using System.Collections.Generic;
using FBS.BusinessLogic.Models;

namespace FBS.BusinessLogic
{
    public interface IExpensesRepository
    {
        int AddNewExpense(Expense expense);
        int AddNewExpenses(List<Expense> expenses);
        int DeleteExpense(int id);
        IEnumerable<Expense> GetExpenses(DateTime startDate, DateTime endDate, int expenseType = 0);
        int UpdateExpense(Expense expense);
    }
}