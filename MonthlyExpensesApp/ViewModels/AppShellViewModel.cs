using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonthlyExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        //[RelayCommand]
        //public async void Logout()
        //{
        //    //await Shell.Current.GoToAsync(nameof(LoginPage));
        //    await Shell.Current.Navigation.PopToRootAsync();
        //}

        [RelayCommand]
        async void Logout()
        {
            if (Preferences.ContainsKey(nameof(App.registrationModel)))
            {
                Preferences.Remove(nameof(App.registrationModel));
            }
           // await Shell.Current.GoToAsync("..");
            await Shell.Current.Navigation.PopToRootAsync();
        }

    }
}
