using MonthlyExpensesApp.ViewModels;

namespace MonthlyExpensesApp.Views;

public partial class LoginPage : ContentPage
{
	private  LoginPageViewModel _loginPageViewModel;
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		_loginPageViewModel = loginPageViewModel;
		this.BindingContext = _loginPageViewModel;
	}
}