using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.ViewModels;
using MonthlyExpensesApp.Views;

namespace MonthlyExpensesApp
{
    public partial class App : Application
    {
        public static RegistrationModel? registrationModel;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();  
           
        }
    }
}
