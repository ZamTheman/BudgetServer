using System.Collections.Generic;
using FBS.DataAccess.Models;

namespace FBS.DataAccess
{
    public interface IExpenseTypesDataAccess
    {
        int AddExpenseType(ExpenseTypeDTO expenseType);
        IEnumerable<ExpenseTypeDTO> GetExpenseTypes();
    }
}