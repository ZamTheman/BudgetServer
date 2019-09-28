using FBS.BusinessLogic.Models;
using FBS.DataAccess.Models;

namespace FBS.BusinessLogic.Helpers
{
    public class Converters
    {
        public static ExpenseDTO MapExpenseToExpenseDto(Expense expense)
        {
            return new ExpenseDTO
            {
                id_utg = expense.id,
                Belopp = expense.amount,
                Fördelning = expense.split,
                Datum = expense.date,
                Kommentar = expense.comment,
                KopieraMedBelopp = expense.copyWithAmount,
                KopieraUtanBelopp = expense.copyWithoutAmount,
                UtgiftId = expense.expenseType.id
            };
        }

        public static Expense MapExpenseDtoToExpense(ExpenseDTO expense)
        {
            return new Expense
            {
                id = expense.id_utg,
                amount = expense.Belopp,
                split = expense.Fördelning,
                date = expense.Datum,
                comment = expense.Kommentar,
                copyWithAmount = expense.KopieraMedBelopp,
                copyWithoutAmount = expense.KopieraUtanBelopp,
                expenseType = new ExpenseType() { id = expense.UtgiftId }
            };
        }

        public static SalaryDTO MapSalaryToSalaryDTO(Salary salary)
        {
            return new SalaryDTO
            {
                id = salary.id,
                InkomstMarie = salary.IncomeMarie,
                InkomstSamuel = salary.IncomeSamuel,
                Datum = salary.date
            };
        }

        public static Salary MapSalaryDTOToSalary(SalaryDTO salary)
        {
            return new Salary
            {
                id = salary.id,
                IncomeMarie = salary.InkomstMarie,
                IncomeSamuel = salary.InkomstSamuel,
                date = salary.Datum
            };
        }

        public static ExpenseTypeDTO MapExpenseTypeToExpenseTypeDTO(ExpenseType expenseType)
        {
            return new ExpenseTypeDTO
            {
                id = expenseType.id,
                Typ = expenseType.name
            };
        }

        public static ExpenseType MapExpenseTypeDTOToExpenseType(ExpenseTypeDTO expenseType)
        {
            return new ExpenseType
            {
                id = expenseType.id,
                name = expenseType.Typ
            };
        }
    }
}
