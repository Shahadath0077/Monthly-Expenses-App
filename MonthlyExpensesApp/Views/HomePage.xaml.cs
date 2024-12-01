using CommunityToolkit.Mvvm.ComponentModel;
using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;



public partial class HomePage : ContentPage
{    
    private ExpensesMainPageViewModel _expensesMainPageViewModel;
    public HomePage(ExpensesMainPageViewModel expensesMainPageViewModel)
    {
        InitializeComponent();

        if (App.registrationModel != null)
        {
            lblUserFullName.Text = App.registrationModel.FullName;            
        }
        _expensesMainPageViewModel = expensesMainPageViewModel;
        this.BindingContext = _expensesMainPageViewModel;
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}