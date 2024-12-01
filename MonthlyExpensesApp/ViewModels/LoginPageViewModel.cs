using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.Services;
using MonthlyExpensesApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.ViewModels
{
    [QueryProperty(nameof(LoginDetail), "LoginDetail")]
    public partial class LoginPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private LoginModel _loginDetail = new LoginModel();

        [ObservableProperty]
        private RegistrationModel registrationModel = new RegistrationModel();

        private readonly ILoginService _loginService;
       
        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [RelayCommand]
        public async Task UserLogin()
        {
            if (LoginDetail.UserName != null && LoginDetail.UserPassword != null)
            {
                //var isUserExist = await _loginService.VerifyLogin(LoginDetail);
                //var isUserExist = await _loginService.VerifyUserLogin(LoginDetail);

                RegistrationModel registrationModel = await _loginService.VerifyUserLogin(LoginDetail);

                if (registrationModel.FullName !=null)
                {
                    if (Preferences.ContainsKey(nameof(App.registrationModel)))
                    {
                        Preferences.Remove(nameof(App.registrationModel));
                    }
                    string userDetails = JsonConvert.SerializeObject(registrationModel);
                  
                    Preferences.Set(nameof(App.registrationModel), userDetails);
                     App.registrationModel = registrationModel;

                    await AppShell.Current.GoToAsync(nameof(HomePage));
                    //await AppShell.Current.GoToAsync(nameof(ExpensesMainPage));
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Message", "User not found!", "OK");
                }
            }
            else
            {               
                await AppShell.Current.DisplayAlert("Message", "Enter user name and password!", "OK");               
            }            
            LoginDetail = new LoginModel();           
        }

        [RelayCommand]
        public async void UserRegistration()
        {
            await AppShell.Current.GoToAsync(nameof(RegistrationPage));
        }
    }
}
