using MonthlyExpensesApp.ViewModels;
using MonthlyExpensesApp.Views;

namespace MonthlyExpensesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RouteNavigation();
        }

        public void RouteNavigation()
        {
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ExpensesMainPage), typeof(ExpensesMainPage));
            Routing.RegisterRoute(nameof(AddMonthPopup), typeof(AddMonthPopup));
            Routing.RegisterRoute(nameof(ExpensesDetailPage), typeof(ExpensesDetailPage));
            Routing.RegisterRoute(nameof(AddUpdateExpensesPage), typeof(AddUpdateExpensesPage));
        }
    }
}
