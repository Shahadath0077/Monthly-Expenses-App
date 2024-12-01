using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.ViewModels
{
    [QueryProperty(nameof(ExpensesDetail), "ExpensesDetail")]
    public partial class AddUpdateExpensesPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ExpensesDetailModel _expensesDetail = new ExpensesDetailModel();

        private readonly IExpensesDetailService _expensesDetailService;
        //ManageExpenseListPage _manageExpenseListPage;

        private ExpensesDetailModel _expensesDetailModel {  get; set; }  

        public AddUpdateExpensesPageViewModel(IExpensesDetailService expensesDetailService)
        {
            _expensesDetailService = expensesDetailService;
            _expensesDetailModel=new ExpensesDetailModel();


        }
        [RelayCommand]
        public async void AddUpdateMonthlyExpenses()
        {
            int response = -1;
            if (ExpensesDetail.ExpensesId > 0)
            {
                response = await _expensesDetailService.UpdateExpenses(ExpensesDetail);
                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Message", "Expenses updated successfully!", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while updating contact", "OK");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ExpensesDetail.ExpensesDescription) && !string.IsNullOrWhiteSpace(ExpensesDetail.ExpensesDate.ToString()) && (ExpensesDetail.Amount!=null))
                {
                    response = await _expensesDetailService.AddExpenses(new Models.ExpensesDetailModel
                    {
                        ExpensesDate = ExpensesDetail.ExpensesDate,
                        Amount = ExpensesDetail.Amount,
                        ExpensesDescription = ExpensesDetail.ExpensesDescription,
                    });

                    if (response > 0)
                    {
                        await Shell.Current.DisplayAlert("Message", "Expenses saved successfully!", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding contact", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Message", "Enter all the required fields!", "OK");
                }
            }
            ExpensesDetail = new ExpensesDetailModel();
        }

    }
}
