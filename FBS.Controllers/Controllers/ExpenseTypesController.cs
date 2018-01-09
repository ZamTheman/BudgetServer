using System.Collections.Generic;
using FBS.BusinessLogic;
using FBS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace FBS.Controllers.Controllers
{
    [Produces("application/json")]
    [Route("api/ExpenseTypes")]
    public class ExpenseTypesController : Controller
    {
        private IExpenseTypesRepository expenseTypesRepository;
        public ExpenseTypesController(IExpenseTypesRepository expenseTypesRepository)
        {
            this.expenseTypesRepository = expenseTypesRepository;
        }

        // GET: api/ExpenseTypes
        [HttpGet]
        public IEnumerable<ExpenseType> Get()
        {
            return expenseTypesRepository.GetExpenseTypes();
        }
        
        // POST: api/ExpenseTypes
        [HttpPost]
        public int Post([FromBody]ExpenseType expenseType)
        {
            return expenseTypesRepository.AddExpenseType(expenseType);
        }
        
    }
}
