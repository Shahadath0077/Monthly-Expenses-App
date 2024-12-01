using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public class RegistrationService : IRegistrationService
    {
        public async Task<int> AddRegistration(RegistrationModel registrationModel)
        {
            await SQLiteDbConnect.ConnectDb();
            return await SQLiteDbConnect._dbConnection.InsertAsync(registrationModel);
        }
    }
}
