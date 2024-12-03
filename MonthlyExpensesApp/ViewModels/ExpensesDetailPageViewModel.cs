using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.Services;
using MonthlyExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.ViewModels
{
    [QueryProperty(nameof(MonthlyExpensesDetail), "MonthlyExpensesDetail")] 
    [QueryProperty(nameof(AddMonthDetail), "AddMonthDetail")]
  
    public partial class ExpensesDetailPageViewModel: ObservableObject
    {
        public ObservableCollection<ExpensesDetailModel> MonthlyExpensesList { get; set; } = new ObservableCollection<ExpensesDetailModel>();

        public ObservableCollection<ExpensesGroupModel> MonthlyGroupExpensesList { get; set; } = new ObservableCollection<ExpensesGroupModel>();


        [ObservableProperty]
        private ExpensesDetailModel _monthlyExpensesDetail = new ExpensesDetailModel();

        [ObservableProperty]
        private AddMonthModel _addMonthDetail = new AddMonthModel();

        
        [ObservableProperty]
        private bool isLblVisible = true;
        [ObservableProperty]
        private bool isListVisible = false;    
        public ExpensesDetailModel expensesDetailModel { get; set; }

        private readonly IExpensesDetailService _expensesDetailService;
       
        public ExpensesDetailPageViewModel(IExpensesDetailService expensesDetailService)
        {
            _expensesDetailService = expensesDetailService;
            expensesDetailModel = new ExpensesDetailModel();          
        }

        [RelayCommand]
        public async Task AddMonthlyExpenses()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateExpensesPage));
        }

        [RelayCommand]
        public async Task DisplayAction(ExpensesDetailModel expensesDetailModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ExpensesDetail", expensesDetailModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateExpensesPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _expensesDetailService.DeleteExpenses(expensesDetailModel);
                if (delResponse > 0)
                {
                    await Shell.Current.DisplayAlert("Message", "Expenses deleted successfully!", "OK");
                    await GetExpensesList();
                }
            }
        }

        [RelayCommand]
        public async Task GetExpensesList()
        {          
            await getexpensesList();       
        } 

        public async Task getexpensesList()
        {
            try
            {
                // clear the list
                MonthlyExpensesList.Clear();
                MonthlyGroupExpensesList.Clear();
                double totalAmount = 0;
               // double totalGroupAmount = 0;

                var expensesList = await _expensesDetailService.GetExpensesList();

                if (expensesList?.Count > 0)
                {
                    IsLblVisible = false;
                    IsListVisible = true;

                    foreach (var expense in expensesList)
                    {
                        //Filter by month
                        if (expense.ExpensesDate.ToString("MMMM") == AddMonthDetail.SelelctedMonth)
                        {
                            totalAmount += Convert.ToDouble(expense.Amount);
                            MonthlyExpensesList.Add(expense);
                        }
                    }

                    // group the list by date
                    var dic = (MonthlyExpensesList.GroupBy(x => x.ExpensesDate.Date).ToDictionary(d => d.Key, d => d.ToList()));

                    foreach (KeyValuePair<DateTime, List<ExpensesDetailModel>> item in dic)
                    {                      
                        MonthlyGroupExpensesList.Add(new ExpensesGroupModel(item.Key, new List<ExpensesDetailModel>(item.Value)));


                        //foreach(var data in item.Value)
                        //{
                        //    totalGroupAmount += Convert.ToDouble(data.Amount);
                        //}
                       
                        //MonthlyExpensesDetail.GroupTotalAmount = totalGroupAmount;
                    }
                    AddMonthDetail.ShowTotalAmount = totalAmount;
                }
                else
                {
                    AddMonthDetail.ShowTotalAmount = totalAmount;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
