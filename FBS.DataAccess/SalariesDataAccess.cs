using Dapper;
using FBS.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FBS.DataAccess
{
    public class SalariesDataAccess : DataAccessBase, ISalariesDataAccess
    {
        public SalariesDataAccess(IConfiguration configuration, ILogger<SalariesDataAccess> logger) : base(configuration, logger)
        {
        }

        public IEnumerable<SalaryDTO> GetSalaries(DateTime startDate, DateTime endDate)
        {
            var selectQuery = "SELECT * FROM inkomster WHERE Datum BETWEEN @startDate AND @endDate";
            try
            {
                using (IDbConnection db = new MySqlConnection(connectionString))
                {
                    logger.LogInformation("Sql connection string: " + this.connectionString);
                    return db.Query<SalaryDTO>
                        (selectQuery,
                        new { startDate, endDate }).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Sql request failed see error: " + ex);
            }
            
            return new List<SalaryDTO>();
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
