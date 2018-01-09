using System;
using FBS.DataAccess.Models;

namespace FBS.DataAccess
{
    public interface ISalariesDataAccess
    {
        int AddNewSalary(SalaryDTO salary);
        SalaryDTO GetSalaryForMonth(DateTime date);
        int UpdateSalary(SalaryDTO salary);
    }
}