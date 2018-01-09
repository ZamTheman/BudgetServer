using System;
using FBS.BusinessLogic.Models;

namespace FBS.BusinessLogic
{
    public interface ISalariesRepository
    {
        int AddNewSalary(Salary salary);
        Salary GetSalaryForMonth(DateTime date);
        int UpdateSalary(Salary salary);
    }
}