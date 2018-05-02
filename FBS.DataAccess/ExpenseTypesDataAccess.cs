using Dapper;
using FBS.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace FBS.DataAccess
{
    public class ExpenseTypesDataAccess : DataAccessBase, IExpenseTypesDataAccess
    {
        public ExpenseTypesDataAccess(IConfiguration configuration, ILogger<ExpenseTypesDataAccess> logger) : base(configuration, logger)
        {
        }

        public IEnumerable<ExpenseTypeDTO> GetExpenseTypes()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                return db.Query<ExpenseTypeDTO>
                    ("SELECT * FROM typer");
            }
        }

        public int AddExpenseType(ExpenseTypeDTO expenseType)
        {
            int result;
            string insertQuery = "INSERT INTO typer (Typ) " +
                "VALUES (@Typ);";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute(insertQuery, new
                {
                    expenseType.Typ
                });
            }
            return result;
        }
    }
}
