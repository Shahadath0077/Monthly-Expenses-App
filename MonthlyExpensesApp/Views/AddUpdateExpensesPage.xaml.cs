using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;

public partial class AddUpdateExpensesPage : ContentPage
{
    //private AddUpdateExpensesPageViewModel _addUpdateExpensesPageViewModel;
    //public AddUpdateExpensesPage(AddUpdateExpensesPageViewModel addUpdateExpensesPageViewModel)
    //{
    //    InitializeComponent();
    //    _addUpdateExpensesPageViewModel = addUpdateExpensesPageViewModel;
    //    this.BindingContext = _addUpdateExpensesPageViewModel;
    //}

    public AddUpdateExpensesPage(AddUpdateExpensesPageViewModel addUpdateExpensesPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = addUpdateExpensesPageViewModel;

    }
}