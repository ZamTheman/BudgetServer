using FBS.BusinessLogic.Helpers;
using FBS.BusinessLogic.Models;
using FBS.DataAccess;
using FBS.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace FBS.BusinessLogic
{
    public class ExpensesRepository : IExpensesRepository
    {
        private IExpensesDataAccess expensesDataAccess;

        public ExpensesRepository(IExpensesDataAccess expensesDataAccess)
        {
            this.expensesDataAccess = expensesDataAccess;
        }

        public IEnumerable<Expense> GetExpenses(DateTime startDate, DateTime endDate, int expenseType = 0)
        {
            IEnumerable<ExpenseDTO> expenseDtos;
            if (expenseType > 0)
                expenseDtos = expensesDataAccess.GetExpenses(startDate, endDate, expenseType);
            else
                expenseDtos = expensesDataAccess.GetExpenses(startDate, endDate);

            var expenses = new List<Expense>();
            foreach (var item in expenseDtos)
            {
                expenses.Add(Converters.MapExpenseDtoToExpense(item));
            }
            return expenses;
        }

        public int AddNewExpense(Expense expense)
        {
            var expenseDTO = Converters.MapExpenseToExpenseDto(expense);
            if(expenseDTO.Kommentar == null)
            {
                expenseDTO.Kommentar = "";
            }
            return expensesDataAccess.AddNewExpense(expenseDTO);
        }

        public int AddNewExpenses(List<Expense> expenses)
        {
            var expenseDTOs = new List<ExpenseDTO>();
            foreach (var item in expenses)
            {
                var expenseDTO = Converters.MapExpenseToExpenseDto(item);
                if (expenseDTO.Kommentar == null)
                {
                    expenseDTO.Kommentar = "";
                }
                expenseDTOs.Add(expenseDTO);
            }
            return expensesDataAccess.AddNewExpenses(expenseDTOs);
        }

        public int UpdateExpense(Expense expense)
        {
            var expenseDTO = Converters.MapExpenseToExpenseDto(expense);
            if (expenseDTO.Kommentar == null)
            {
                expenseDTO.Kommentar = "";
            }
            return expensesDataAccess.UpdateExpense(expenseDTO);
        }

        public int DeleteExpense(int id)
        {
            return expensesDataAccess.DeleteExpense(id);
        }
        

    }
}
