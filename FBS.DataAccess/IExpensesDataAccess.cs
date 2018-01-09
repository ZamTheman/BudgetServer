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
        List<ExpenseDTO> GetExpensesForMonth(DateTime date);
        int UpdateExpense(ExpenseDTO expense);
    }
}