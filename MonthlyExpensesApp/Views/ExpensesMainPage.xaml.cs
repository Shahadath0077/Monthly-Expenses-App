using CommunityToolkit.Mvvm.ComponentModel;
using MonthlyExpensesApp.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace MonthlyExpensesApp.Views;

public partial class ExpensesMainPage : ContentPage
{
    private ExpensesMainPageViewModel _expensesMainPageViewModel;
    public ExpensesMainPage(ExpensesMainPageViewModel expensesMainPageViewModel)
	{
		InitializeComponent();

        _expensesMainPageViewModel= expensesMainPageViewModel;
     
        this.BindingContext = _expensesMainPageViewModel;
        _expensesMainPageViewModel.GetMonthlListCommand.Execute(null);     
    }
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    _expensesMainPageViewModel.GetMonthlListCommand.Execute(null);
    //}


}