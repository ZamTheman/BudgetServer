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
        public IEnumerable<Expense> Get()
        {
            return expensesRepository.GetExpensesForMonth(DateTime.Now);
        }

        // GET: api/Expenses/2017-12-01
        [HttpGet("{date}", Name = "GetExpensesByDate")]
        public IEnumerable<Expense> Get(DateTime date)
        {
            return expensesRepository.GetExpensesForMonth(date);
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
