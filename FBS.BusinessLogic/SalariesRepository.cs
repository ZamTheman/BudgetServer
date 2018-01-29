using FBS.BusinessLogic.Helpers;
using FBS.BusinessLogic.Models;
using FBS.DataAccess;
using System.Collections.Generic;
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

        public IEnumerable<Salary> GetSalaries(DateTime startDate, DateTime endDate)
        {
            var salaryDTO = salariesDataAccess.GetSalaries(startDate, endDate);
            var salaries = new List<Salary>();
            foreach (var item in salaryDTO)
            {
                salaries.Add(Converters.MapSalaryDTOToSalary(item));
            }
            return salaries;
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
