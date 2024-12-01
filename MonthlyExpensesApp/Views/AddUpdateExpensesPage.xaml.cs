using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;

public partial class AddUpdateExpensesPage : ContentPage
{
    // private ExpensesDetailPageViewModel _expensesDetailViewModel;

    //   public AddUpdateExpensesPage(ExpensesDetailPageViewModel expensesDetailViewModel)
    //{
    //	InitializeComponent();
    //       _expensesDetailViewModel = expensesDetailViewModel;
    //       this.BindingContext = _expensesDetailViewModel;

    //   }

    private AddUpdateExpensesPageViewModel _addUpdateExpensesPageViewModel;
    public AddUpdateExpensesPage(AddUpdateExpensesPageViewModel addUpdateExpensesPageViewModel)
    {
        InitializeComponent();
        _addUpdateExpensesPageViewModel = addUpdateExpensesPageViewModel;
        this.BindingContext = _addUpdateExpensesPageViewModel;

    }
}