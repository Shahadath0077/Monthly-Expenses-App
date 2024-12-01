using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public class LoginService : ILoginService
    {
        //public async Task<bool> VerifyLogin(LoginModel loginModel)
        //{
        //    bool userExist = false;
        //    await SQLiteDbConnect.ConnectDb();
        //    var exist = await SQLiteDbConnect._dbConnection.Table<RegistrationModel>().Where
        //                           (c => c.UserName == loginModel.UserName &&
        //                           c.UserPassword == loginModel.UserPassword).ToListAsync();
        //    if (exist.Count > 0)
        //    {
        //        userExist = true;
        //    }
        //    else
        //    {
        //        userExist = false;
        //    }
        //    return userExist;

        //    //return exist.Count > 0;
        //}

        public async Task<RegistrationModel> VerifyUserLogin(LoginModel loginModel)
        {
            RegistrationModel registrationModel = new RegistrationModel();

            await SQLiteDbConnect.ConnectDb();
            var exist = await SQLiteDbConnect._dbConnection.Table<RegistrationModel>().Where
                                   (c => c.UserName == loginModel.UserName &&
                                   c.UserPassword == loginModel.UserPassword).ToListAsync();

            if (exist.Count > 0)
            {
                foreach (var data in exist)
                {
                    registrationModel.FullName = data.FullName;
                }
            }
            return registrationModel;
        }
    }
}
