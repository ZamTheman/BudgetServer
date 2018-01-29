using System;
using System.Collections.Generic;
using FBS.BusinessLogic.Models;
using FBS.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace FBS.Controllers.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private IExpensesRepository expensesRepository;
        public ExpensesController(IExpensesRepository expensesRepository)
        {
            this.expensesRepository = expensesRepository;
        }

        // GET: api/Expenses
        [HttpGet]
        public IEnumerable<Expense> Get(
            [FromQuery(Name = "startDate")] DateTime startDate,
            [FromQuery(Name = "endDate")] DateTime endDate,
            [FromQuery(Name = "expenseType")] int expenseType)
        {
            // If no relevent month is set, use current month
            if(startDate.Year < 2000)
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var tempDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                endDate = tempDate - TimeSpan.FromDays(1);
            }

            return expensesRepository.GetExpenses(startDate, endDate, expenseType);
        }
        
        // POST: api/Expenses
        [HttpPost]
        public int Post([FromBody]Expense expense) => expensesRepository.AddNewExpense(expense);

        // POST: api/Expenses/multiple
        [HttpPost("multiple")]
        public int Post([FromBody]List<Expense> expenses) => expensesRepository.AddNewExpenses(expenses);

        // PUT: api/Expenses/5
        [HttpPut]
        public int Put([FromBody]Expense expense) => expensesRepository.UpdateExpense(expense);
        
        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public int Delete(int id) => expensesRepository.DeleteExpense(id);
    }
}
