using System;
using FBS.BusinessLogic;
using FBS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace FBS.Controllers.Controllers
{
    [Produces("application/json")]
    [Route("api/Salaries")]
    public class SalariesController : Controller
    {
        private ISalariesRepository salariesRepository;
        public SalariesController(ISalariesRepository salariesRepository)
        {
            this.salariesRepository = salariesRepository;
        }

        // GET: api/Salaries
        [HttpGet("{date}", Name = "GetSalariesByDate")]
        public Salary Get(DateTime date)
        {
            return salariesRepository.GetSalaryForMonth(date);
        }
        
        // POST: api/Salaries
        [HttpPost]
        public int Post([FromBody]Salary salary)
        {
            return salariesRepository.AddNewSalary(salary);
        }
        
        // PUT: api/Salaries/5
        [HttpPut]
        public int Put([FromBody]Salary salary)
        {
            return salariesRepository.UpdateSalary(salary);
        }
    }
}
