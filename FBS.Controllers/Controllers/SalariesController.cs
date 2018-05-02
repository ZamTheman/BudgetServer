using System;
using System.Collections.Generic;
using FBS.BusinessLogic;
using FBS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FBS.Controllers.Controllers
{
    [Produces("application/json")]
    [Route("api/Salaries")]
    public class SalariesController : Controller
    {
        private readonly ISalariesRepository salariesRepository;
        private readonly ILogger<SalariesController> logger;

        public SalariesController(ISalariesRepository salariesRepository, ILogger<SalariesController> logger)
        {
            this.salariesRepository = salariesRepository;
            this.logger = logger;
        }

        // GET: api/Salaries
        [HttpGet]
        public IEnumerable<Salary> Get(
            [FromQuery(Name = "startDate")] DateTime startDate,
            [FromQuery(Name = "endDate")] DateTime endDate)
        {
            logger.LogInformation("Salaries get request received. Parameters: startDate: " + startDate + " endDate: " + endDate);
            return salariesRepository.GetSalaries(startDate, endDate);
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
