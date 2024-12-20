using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.Services;


namespace MonthlyExpensesApp.ViewModels
{
    [QueryProperty(nameof(ExpensesDetail), "ExpensesDetail")]
    public partial class AddUpdateExpensesPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ExpensesDetailModel _expensesDetail = new ExpensesDetailModel();

        private readonly IExpensesDetailService _expensesDetailService;         
        public AddUpdateExpensesPageViewModel(IExpensesDetailService expensesDetailService)
        {
            _expensesDetailService = expensesDetailService;            
        }
        [RelayCommand]
        public async Task AddUpdateMonthlyExpenses()
        {
            try
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
                        await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while updating expenses", "OK");
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(ExpensesDetail.ExpensesDescription) && !string.IsNullOrWhiteSpace(ExpensesDetail.ExpensesDate.ToString()) && (ExpensesDetail.Amount != null))
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
                            await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding expenses", "OK");
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Message", "Enter all the required fields!", "OK");
                    }
                    ExpensesDetail = new ExpensesDetailModel();
                }
               
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"{ex}", "OK");
                //Console.WriteLine(ex.ToString());
            }           
        }
    }
}
