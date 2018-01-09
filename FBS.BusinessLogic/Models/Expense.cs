using System;

namespace FBS.BusinessLogic.Models
{
    public class Expense
    {
        public ExpenseType expenseType { get; set; }
        public int amount { get; set; }
        public string split { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public bool copyWithAmount { get; set; }
        public bool copyWithoutAmount { get; set; }
        public int id { get; set; }
    }
}
