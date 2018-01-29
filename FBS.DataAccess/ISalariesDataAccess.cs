using System;
using System.Collections.Generic;
using FBS.DataAccess.Models;

namespace FBS.DataAccess
{
    public interface ISalariesDataAccess
    {
        int AddNewSalary(SalaryDTO salary);
        IEnumerable<SalaryDTO> GetSalaries(DateTime startDate, DateTime endDate);
        int UpdateSalary(SalaryDTO salary);
    }
}