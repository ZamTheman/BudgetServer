using System.Collections.Generic;
using FBS.BusinessLogic.Models;

namespace FBS.BusinessLogic
{
    public interface IExpenseTypesRepository
    {
        int AddExpenseType(ExpenseType expenseType);
        IEnumerable<ExpenseType> GetExpenseTypes();
    }
}