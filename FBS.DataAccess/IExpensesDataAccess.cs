using System;
using System.Collections.Generic;
using FBS.DataAccess.Models;

namespace FBS.DataAccess
{
    public interface IExpensesDataAccess
    {
        int AddNewExpense(ExpenseDTO expense);
        int AddNewExpenses(List<ExpenseDTO> expenses);
        int DeleteExpense(int id);
        IEnumerable<ExpenseDTO> GetExpenses(DateTime startDate, DateTime endDate, int expenseType = 0);
        int UpdateExpense(ExpenseDTO expense);
    }
}