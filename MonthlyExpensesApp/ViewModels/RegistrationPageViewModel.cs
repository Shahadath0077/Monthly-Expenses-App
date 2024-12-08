using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.Services;
using MonthlyExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.ViewModels
{
    [QueryProperty(nameof(RegistrationDetail), "RegistrationDetail")]
    public partial class RegistrationPageViewModel : ObservableObject
    {
        [ObservableProperty]      
        private RegistrationModel _registrationDetail = new RegistrationModel();

        private readonly IRegistrationService _registrationService;

        public RegistrationPageViewModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [RelayCommand]
        public async Task RegistrationSubmit()
        {
            int response = -1;

            if (RegistrationDetail.FullName != null && RegistrationDetail.UserName != null && RegistrationDetail.UserPassword != null)
            {              
                response = await _registrationService.AddRegistration(new RegistrationModel
                {
                    FullName = RegistrationDetail.FullName,
                    UserName = RegistrationDetail.UserName,
                    UserPassword = RegistrationDetail.UserPassword,
                });
                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Message", "User registration successful!", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while doing registration", "OK");
                }
                await AppShell.Current.GoToAsync(nameof(LoginPage));
            }
            else
            {
                await AppShell.Current.DisplayAlert("Message", "Enter user details!", "OK");
            }
            RegistrationDetail = new RegistrationModel();
        }

        [RelayCommand]
        public async Task NavigateToLoginPage()
        {
            await AppShell.Current.GoToAsync(("/LoginPage"));
        }

    }
}
