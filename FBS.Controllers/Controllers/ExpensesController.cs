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
            [FromQuery(Name = "expenseType")] int expenseType)
        {
            // If no relevent month is set, use current month
            var date = startDate.Year > 2000 ? startDate : DateTime.Now;

            return expensesRepository.GetExpensesForMonth(date, expenseType);
        }
        
        // POST: api/Expenses
        [HttpPost]
        public int Post([FromBody]Expense expense)
        {
            return expensesRepository.AddNewExpense(expense);
        }

        // POST: api/Expenses/multiple
        [HttpPost("multiple")]
        public int Post([FromBody]List<Expense> expenses)
        {
            return expensesRepository.AddNewExpenses(expenses);
        }

        // PUT: api/Expenses/5
        [HttpPut]
        public int Put([FromBody]Expense expense)
        {
            return expensesRepository.UpdateExpense(expense);
        }
        
        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return expensesRepository.DeleteExpense(id);
        }
    }
}
