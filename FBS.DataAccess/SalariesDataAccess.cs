using Dapper;
using FBS.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace FBS.DataAccess
{
    public class SalariesDataAccess : DataAccessBase, ISalariesDataAccess
    {
        public SalariesDataAccess(IConfiguration configuration) : base(configuration)
        {
        }

        public SalaryDTO GetSalaryForMonth(DateTime date)
        {
            using(IDbConnection db = new MySqlConnection(connectionString))
            {
                return db.Query<SalaryDTO>
                    ("SELECT * FROM inkomster WHERE YEAR(Datum) = @Y AND MONTH(Datum) = @M ORDER BY id DESC LIMIT 1",
                    new { Y = date.Year, M = date.Month }).FirstOrDefault();
            }
        }

        public int AddNewSalary(SalaryDTO salary)
        {
            int result;
            string insertQuery = "INSERT INTO inkomster (InkomstMarie, InkomstSamuel, Datum) " +
                "VALUES (@InkomstMarie, @InkomstSamuel, @Datum);";
            using(IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute(insertQuery, new
                {
                    salary.InkomstMarie,
                    salary.InkomstSamuel,
                    salary.Datum
                });
            }
            return result;
        }

        public int UpdateSalary(SalaryDTO salary)
        {
            int result;
            string updateQuery = "UPDATE inkomster SET " +
                "InkomstMarie = @InkomstMarie," +
                "InkomstSamuel = @InkomstSamuel," +
                "Datum = @Datum " +
                "WHERE id = @id";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute(updateQuery, salary);
            }
            return result;
        }


    }
}
