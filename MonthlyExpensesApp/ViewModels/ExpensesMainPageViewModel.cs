using CommunityToolkit.Maui.Alerts;
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
    [QueryProperty(nameof(AddMonthDetail), "AddMonthDetail")]
    [QueryProperty(nameof(MonthlyExpensesDetail), "MonthlyExpensesDetail")]
    public partial class ExpensesMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ExpensesDetailModel _monthlyExpensesDetail = new ExpensesDetailModel();

        [ObservableProperty]
        private AddMonthModel _addMonthDetail = new AddMonthModel();      

        [ObservableProperty]
        private bool isLblVisible = true;
        [ObservableProperty]
        private bool isListVisible = false;
        public ObservableCollection<AddMonthModel> AddMonthList { get; set; } = new ObservableCollection<AddMonthModel>();

        public AddMonthModel addMonthModel { get; set; }

        private readonly IAddMonthService _addMonthService;
        private readonly IExpensesDetailService _expensesDetailService;

        public ExpensesMainPageViewModel(IAddMonthService addMonthService, IExpensesDetailService expensesDetailService)
        {
            _addMonthService = addMonthService;
            _expensesDetailService= expensesDetailService;         
            addMonthModel = new AddMonthModel();
        }

        [RelayCommand]
        public async Task NavigateToExpensesMainPage()
        {
            await AppShell.Current.GoToAsync(nameof(ExpensesMainPage));
        }

        [RelayCommand]
        public async Task NavigateToExpensesDetailPage(AddMonthModel addMonthModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("AddMonthDetail", addMonthModel);
            await AppShell.Current.GoToAsync(nameof(ExpensesDetailPage), navParam);        
        }

        [RelayCommand]
        public void OpenPopupMonth()
        {
            AddMonthPopup popup = new AddMonthPopup(this);            
            Application.Current?.MainPage?.ShowPopup(popup);
        }

        [RelayCommand]
        public async Task SaveMonth()
        {
            if (AddMonthDetail.SelelctedMonth == null || AddMonthDetail.SelelctedMonth == "Select a month")
            {
                await Shell.Current.DisplayAlert("Message", "Please select a month", "OK");
            }
            else
            {
                var response = await _addMonthService.AddMonth(new AddMonthModel
                {
                    Id = AddMonthDetail.Id,
                    SelelctedMonth = AddMonthDetail.SelelctedMonth,                   
                });
                if (response > 0)
                {
                    await GetMonthlList();
                    AddMonthDetail = new AddMonthModel();
                    await Shell.Current.DisplayAlert("Message", "Month created successfully!", "OK");
                }
                else
                {
                    AddMonthDetail = new AddMonthModel();
                    await Shell.Current.DisplayAlert("Message", "Month already exist!", "OK");
                }
              
            }    
        }

        [RelayCommand]
        public void CancelSaveMonth()
        {           
            AddMonthDetail = new AddMonthModel();
        }

        [RelayCommand]
        public async Task GetMonthlList()
        {            
            AddMonthList.Clear();
            var monthList = await _addMonthService.GetMonthList();
            if (monthList?.Count > 0)
            {
                IsListVisible = true;
                IsLblVisible = false;
                //monthlyExpensesList = monthlyExpensesList.OrderByDescending(f => f.SelelctedMonth).ToList();

                foreach (var month in monthList)
                {
                    AddMonthList.Add(month);
                }
            }
        }

        public async Task ShowMonthlyAmount()
        {           
            var expensesList = await _expensesDetailService.GetExpensesList();
            double totalAmount = 0;
            foreach (var expense in expensesList)
            {                
                if (expense.ExpensesDate.ToString("MMMM") == AddMonthDetail.SelelctedMonth)
                {
                    totalAmount += Convert.ToDouble(expense.Amount);                   
                }
            }

            addMonthModel.ShowTotalAmount = totalAmount;
        }
       
    }
}
