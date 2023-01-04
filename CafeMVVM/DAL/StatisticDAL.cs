using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.DAL
{
    public class StatisticDAL : BaseDAL
    {
        public List<StatisticModel> MenuStatisticsByDay(int day)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@day";
            values[0] = day;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_MenuStatisticsByDay", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        public List<StatisticModel> MenuStatisticsByMonth(int month)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@month";
            values[0] = month;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_MenuStatisticsByMonth", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        public List<StatisticModel> MenuStatisticsByYear(object year)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@year";
            values[0] = year;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_MenuStatisticsByYear", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        // Doanh thu
        public List<StatisticModel> RevenueByDay(int day)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@day";
            values[0] = day;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_RevenueByDay", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        public List<StatisticModel> RevenueByMonth(int month)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@month";
            values[0] = month;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_RevenueByMonth", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        public List<StatisticModel> RevenueByYear(object year)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@year";
            values[0] = year;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_RevenueByYear", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
        public List<StatisticModel> LoadMenuListOfTable_Statistics(int receiptId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@receiptId";
            values[0] = receiptId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadMenuListOfTable_Statistics", name, values, parameter));
            return JsonConvert.DeserializeObject<List<StatisticModel>>(json);
        }
    }
}
