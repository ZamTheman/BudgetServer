﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FBS.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace FBS.DataAccess
{
    public class ExpensesDataAccess : DataAccessBase, IExpensesDataAccess
    {
        public ExpensesDataAccess(IConfiguration configuration) : base(configuration)
        {
        }

        public List<ExpenseDTO> GetExpensesForMonth(DateTime date, int expenseType = 0)
        {
            string searchQuery = "SELECT * FROM utgifter WHERE YEAR(Datum) = @Y AND MONTH(Datum) = @M";
            if(expenseType > 0)
            {
                searchQuery += " AND UtgiftId = @UtgId";
            }

            var list = new List<ExpenseDTO>();
            using(IDbConnection db = new MySqlConnection(connectionString))
            {
                list = db.Query<ExpenseDTO>
                    (searchQuery, new {
                        Y = date.Year, M = date.Month, UtgId = expenseType
                    }).ToList();
            }
            return list;
        }

        public int AddNewExpense(ExpenseDTO expense)
        {
            int result;
            string insertQuery = "INSERT INTO utgifter (Belopp, Fördelning, Datum, " +
                "Kommentar, KopieraUtanBelopp, KopieraMedBelopp, UtgiftId) VALUES " +
                "(@Belopp, @Fördelning, @Datum, @Kommentar, @KopieraUtanBelopp, " +
                "@KopieraMedBelopp, @UtgiftId); " +
                "SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER);";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Query<int>
                    (insertQuery, expense).Single();
            }
            return result;
        }

        public int AddNewExpenses(List<ExpenseDTO> expenses)
        {
            int result;
            string insertQuery = "INSERT INTO utgifter (Belopp, Fördelning, Datum, " +
                "Kommentar, KopieraUtanBelopp, KopieraMedBelopp, UtgiftId) VALUES " +
                "(@Belopp, @Fördelning, @Datum, @Kommentar, @KopieraUtanBelopp, " +
                "@KopieraMedBelopp, @UtgiftId); ";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute
                    (insertQuery, expenses);
            }
            return result;
        }

        public int UpdateExpense(ExpenseDTO expense)
        {
            int result;
            string updateQuery = "UPDATE utgifter SET " +
                "Belopp = @Belopp," +
                "Fördelning = @Fördelning," +
                "Datum = @Datum," +
                "Kommentar = @Kommentar," +
                "KopieraUtanBelopp = @KopieraUtanBelopp," +
                "KopieraMedBelopp = @KopieraMedBelopp," +
                "UtgiftId = @UtgiftId " +
                "WHERE id_utg = @id_utg";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute
                    (updateQuery, expense);
            }
            return result;
        }

        public int DeleteExpense(int id)
        {
            int result;
            string deleteQuery = "DELETE FROM utgifter " +
                "WHERE id_utg = @Id";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                result = db.Execute
                    (deleteQuery, new { id });
            }
            return result;
        }
    }
}
