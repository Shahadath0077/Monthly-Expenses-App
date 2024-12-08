using SQLite;
using MonthlyExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.SQLiteHelper
{  
    public class SQLiteDbConnect
    {
        public static SQLiteAsyncConnection? _dbConnection;
        public static async Task ConnectDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MonthlyExpenses.db");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<RegistrationModel>();
                await _dbConnection.CreateTableAsync<AddMonthModel>();
                await _dbConnection.CreateTableAsync<ExpensesDetailModel>();

            }
        }

    }
}
