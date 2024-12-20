using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MonthlyExpensesApp.Services;
using MonthlyExpensesApp.ViewModels;
using MonthlyExpensesApp.Views;

namespace MonthlyExpensesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Views Registration
            builder.Services.AddSingleton<RegistrationPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<ExpensesMainPage>();
            builder.Services.AddSingleton<AddMonthPopup>();
            builder.Services.AddSingleton<ExpensesDetailPage>();
            builder.Services.AddTransient<AddUpdateExpensesPage>();


            // ViewModels Registration
            builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddSingleton<RegistrationPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<ExpensesMainPageViewModel>();
            builder.Services.AddSingleton<ExpensesDetailPageViewModel>();
            builder.Services.AddTransient<AddUpdateExpensesPageViewModel>();


            // Services Registration
            builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<IAddMonthService,AddMonthService>();
            builder.Services.AddSingleton<IExpensesDetailService, ExpensesDetailService>();

            return builder.Build();
        }
    }
}
