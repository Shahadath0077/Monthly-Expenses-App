using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Models
{
    public partial class AddMonthModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? SelelctedMonth { get; set; }

        [ObservableProperty]
        public double showTotalAmount = 0;

        //public double TotalExpensesAmount { get; set; }

    }
}
