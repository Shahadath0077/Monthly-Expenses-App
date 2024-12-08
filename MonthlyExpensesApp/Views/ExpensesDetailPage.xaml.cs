using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;

public partial class ExpensesDetailPage : ContentPage
{
    private ExpensesDetailPageViewModel _expensesDetailViewModel;

    public ExpensesDetailPage(ExpensesDetailPageViewModel expensesDetailViewModel)
	{
		InitializeComponent();
        _expensesDetailViewModel= expensesDetailViewModel;
        this.BindingContext = _expensesDetailViewModel;


       // _expensesDetailViewModel.GetExpensesListCommand.Execute(null);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        

        _expensesDetailViewModel.GetExpensesListCommand.Execute(null);
    }

    public void ChangeLabel()
    {
        
    }
}