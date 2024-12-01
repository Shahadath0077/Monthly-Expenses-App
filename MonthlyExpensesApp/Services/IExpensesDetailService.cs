using MonthlyExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public interface IExpensesDetailService
    {
        Task<List<ExpensesDetailModel>> GetExpensesList();
        Task<int> AddExpenses(ExpensesDetailModel expensesDetailModel);
        Task<int> UpdateExpenses(ExpensesDetailModel expensesDetailModel);
        Task<int> DeleteExpenses(ExpensesDetailModel expensesDetailModel);


    }
}
