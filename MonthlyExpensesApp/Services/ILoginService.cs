using MonthlyExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public interface ILoginService
    {
        //Task<bool> VerifyLogin(LoginModel loginModel);
        Task<RegistrationModel> VerifyUserLogin(LoginModel loginModel);
    }
}
