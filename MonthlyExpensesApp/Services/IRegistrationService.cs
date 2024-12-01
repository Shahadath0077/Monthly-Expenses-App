using MonthlyExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public interface IRegistrationService
    {
        Task<int> AddRegistration(RegistrationModel registrationModel);
    }
}
