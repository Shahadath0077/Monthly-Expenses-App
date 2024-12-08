using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Models
{
    public partial class ExpensesDetailModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ExpensesId { get; set; }
        public string? ExpensesDescription { get; set; }
        public double? Amount { get; set; }       
        public DateTime ExpensesDate { get; set; } = DateTime.Now;     
        public double? GroupTotalAmount { get; set; }
    }
    public class ExpensesGroupModel : List<ExpensesDetailModel>
    {
        public DateTime ExpensesDate { get; set; }
        public double? Amount { get; set; }       
        public ExpensesGroupModel(DateTime expensesDate, List<ExpensesDetailModel> expensesList) : base(expensesList)
        {
            ExpensesDate = expensesDate;
            Amount = expensesList.Where(x => x.Amount.HasValue).Sum(x => x.Amount.Value);           
        }
    }
}
