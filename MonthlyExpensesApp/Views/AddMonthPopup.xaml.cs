using CommunityToolkit.Maui.Views;
using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;

public partial class AddMonthPopup : Popup
{
    private ExpensesMainPageViewModel _expensesMainPageViewModel;
    public AddMonthPopup(ExpensesMainPageViewModel expensesMainPageViewModel)
	{
		InitializeComponent();
        _expensesMainPageViewModel=expensesMainPageViewModel;
        this.BindingContext = _expensesMainPageViewModel;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}