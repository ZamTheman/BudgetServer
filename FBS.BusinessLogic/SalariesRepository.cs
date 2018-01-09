using FBS.BusinessLogic.Helpers;
using FBS.BusinessLogic.Models;
using FBS.DataAccess;
using System;

namespace FBS.BusinessLogic
{
    public class SalariesRepository : ISalariesRepository
    {
        private ISalariesDataAccess salariesDataAccess;

        public SalariesRepository(ISalariesDataAccess salariesDataAcces)
        {
            this.salariesDataAccess = salariesDataAcces;
        }

        public Salary GetSalaryForMonth(DateTime date)
        {
            var salaryDTO = salariesDataAccess.GetSalaryForMonth(date);
            var salary = salaryDTO != null ? Converters.MapSalaryDTOToSalary(salaryDTO) : null;
            return salary;
        }

        public int AddNewSalary(Salary salary)
        {
            return salariesDataAccess.AddNewSalary(Converters.MapSalaryToSalaryDTO(salary));
        }

        public int UpdateSalary(Salary salary)
        {
            return salariesDataAccess.UpdateSalary(Converters.MapSalaryToSalaryDTO(salary));
        }

    }
}
