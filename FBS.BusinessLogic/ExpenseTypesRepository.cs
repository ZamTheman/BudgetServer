using FBS.BusinessLogic.Helpers;
using FBS.BusinessLogic.Models;
using FBS.DataAccess;
using System.Collections.Generic;

namespace FBS.BusinessLogic
{
    public class ExpenseTypesRepository : IExpenseTypesRepository
    {
        private IExpenseTypesDataAccess expenseTypesDataAccess;

        public ExpenseTypesRepository(IExpenseTypesDataAccess expenseTypesDataAccess)
        {
            this.expenseTypesDataAccess = expenseTypesDataAccess;
        }

        public IEnumerable<ExpenseType> GetExpenseTypes()
        {
            var expenseTypeDTOs = expenseTypesDataAccess.GetExpenseTypes();
            var expenseTypes = new List<ExpenseType>();
            foreach (var item in expenseTypeDTOs)
            {
                expenseTypes.Add(Converters.MapExpenseTypeDTOToExpenseType(item));
            }

            return expenseTypes;
        }

        public int AddExpenseType(ExpenseType expenseType)
        {
            return expenseTypesDataAccess.AddExpenseType(Converters.MapExpenseTypeToExpenseTypeDTO(expenseType));
        }
    }
}
