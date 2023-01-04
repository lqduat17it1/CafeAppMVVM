using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeMVVM.Models;

namespace CafeMVVM.DAL
{
    public class MenuDAL : BaseDAL
    {
        public List<MenuModel> LoadMenuCategories()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_LoadMenuCategories"));
            return JsonConvert.DeserializeObject<List<MenuModel>>(json);
        }
        public List<MenuModel> LoadMenu(int mcId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mcId";
            values[0] = mcId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadMenu", name, values, parameter));
            return JsonConvert.DeserializeObject<List<MenuModel>>(json);
        }
        public bool AddMenuCategories(string mcName)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mcName";
            values[0] = mcName;
            return Execute("sp_AddMenuCategories", name, values, parameter);
        }
        public bool DeleteMenuCategories(int mcId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mcId";
            values[0] = mcId;
            return Execute("sp_DeleteMenuCategories", name, values, parameter);
        }
        public bool AddMenu(string MenuName, double price, int mcId)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MenuName";
            name[1] = "@price";
            name[2] = "@mcId";
            values[0] = MenuName;
            values[1] = price;
            values[2] = mcId;
            return Execute("sp_AddMenu", name, values, parameter);
        }
        public bool DeleteMenu(int menuId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@menuId";
            values[0] = menuId;
            return Execute("sp_DeleteMenu", name, values, parameter);
        }
        public bool AddDiscount(int menuId, int discount)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@menuId";
            name[1] = "@discount";
            values[0] = menuId;
            values[1] = discount;
            return Execute("sp_AddDiscount", name, values, parameter);
        }
        public bool DeleteDiscount(int menuId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@menuId";
            values[0] = menuId;
            return Execute("sp_DeleteDiscount", name, values, parameter);
        }
        public bool EditMenuPrice(int menuId, double price)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@menuId";
            name[1] = "@price";
            values[0] = menuId;
            values[1] = price;
            return Execute("sp_EditMenuPrice", name, values, parameter);
        }
    }
}
