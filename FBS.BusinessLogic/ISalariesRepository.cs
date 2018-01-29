using System;
using System.Collections.Generic;
using FBS.BusinessLogic.Models;

namespace FBS.BusinessLogic
{
    public interface ISalariesRepository
    {
        int AddNewSalary(Salary salary);
        IEnumerable<Salary> GetSalaries(DateTime startDate, DateTime endDate);
        int UpdateSalary(Salary salary);
    }
}