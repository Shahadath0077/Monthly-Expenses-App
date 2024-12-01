using MonthlyExpensesApp.Models;
using MonthlyExpensesApp.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpensesApp.Services
{
    public class AddMonthService : IAddMonthService
    {
        public async Task<int> AddMonth(AddMonthModel addMonthModel)
        {
           
            int result = 0;
            await SQLiteDbConnect.ConnectDb();
            var duplicateCount = await SQLiteDbConnect._dbConnection.Table<AddMonthModel>().Where(x=>x.SelelctedMonth==addMonthModel.SelelctedMonth).ToListAsync();

            if (duplicateCount.Count > 0)
            {
                await SQLiteDbConnect._dbConnection.DeleteAsync(addMonthModel);
                return result;
            }
            else 
            {
                return await SQLiteDbConnect._dbConnection.InsertAsync(addMonthModel);
            }
        }

        public async Task<List<AddMonthModel>> GetMonthList()
        {
            await SQLiteDbConnect.ConnectDb();
            var monthList = await SQLiteDbConnect._dbConnection.Table<AddMonthModel>().ToListAsync();
            return monthList;
        }
    }
}
