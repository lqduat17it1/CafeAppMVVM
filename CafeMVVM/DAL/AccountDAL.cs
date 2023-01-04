using CafeMVVM.Models;
using CafeMVVM.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.DAL
{
    public class AccountDAL : BaseDAL
    {
        public List<AccountModel> LoadAccount()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_LoadAccount"));
            return JsonConvert.DeserializeObject<List<AccountModel>>(json);
        }

        public bool AddNewAccount(AccountModel accountModel)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@username";
            name[1] = "@password";
            name[2] = "@role";
            name[3] = "@fullname";
            values[0] = accountModel.Username;
            values[1] = accountModel.Password;
            values[2] = accountModel.Role;
            values[3] = accountModel.FullName;
            return Execute("sp_AddNewAccount", name, values, parameter);
        }

        public bool DeleteAccount(AccountModel accountModel)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@username";
            values[0] = accountModel.Username;
            return Execute("sp_DeleteAccount", name, values, parameter);
        }

        public bool ResetPassword(AccountModel accountModel)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@username";
            values[0] = accountModel.Username;
            return Execute("sp_ResetPassword", name, values, parameter);
        }

        public List<AccountModel> LoginCheck(AccountModel accountModel)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@username";
            values[0] = accountModel.Username;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoginCheck", name, values, parameter));
            return JsonConvert.DeserializeObject<List<AccountModel>>(json);
        }
    }
}
