using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public class ExpensesDetailService : IExpensesDetailService
    {
        public async Task<int> AddExpenses(ExpensesDetailModel expensesDetailModel)
        {
            await SQLiteDbConnect.ConnectDb();
            return await SQLiteDbConnect._dbConnection.InsertAsync(expensesDetailModel);
        }

        public async Task<int> DeleteExpenses(ExpensesDetailModel expensesDetailModel)
        {
            await SQLiteDbConnect.ConnectDb();
            return await SQLiteDbConnect._dbConnection.DeleteAsync(expensesDetailModel);
        }

        public async Task<List<ExpensesDetailModel>> GetExpensesList()
        {
            await SQLiteDbConnect.ConnectDb();
            var expensesList = await SQLiteDbConnect._dbConnection.Table<ExpensesDetailModel>().ToListAsync();
            return expensesList;
        }

        public async Task<int> UpdateExpenses(ExpensesDetailModel expensesDetailModel)
        {
            await SQLiteDbConnect.ConnectDb();
            return await SQLiteDbConnect._dbConnection.UpdateAsync(expensesDetailModel);
        }
    }
}
