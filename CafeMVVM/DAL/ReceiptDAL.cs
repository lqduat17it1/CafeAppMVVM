using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.DAL
{
    public class ReceiptDAL : BaseDAL
    {
        public List<ReceiptModel> LoadMenuListOfTable(int tableId, int receiptId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            name[1] = "@receiptId";
            values[0] = tableId;
            values[1] = receiptId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadMenuListOfTable", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ReceiptModel>>(json);
        }
        public List<ReceiptModel> GetReceiptIDByTableAndArea(int tableId, int areaId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            name[1] = "@areaId";
            values[0] = tableId;
            values[1] = areaId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_GetReceiptIDByTableAndArea", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ReceiptModel>>(json);
        }
        public bool AddReceipt(object createdDate, int tableId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@createdDate";
            name[1] = "@tableId";
            values[0] = createdDate;
            values[1] = tableId;
            return Execute("sp_AddReceipt", name, values, parameter);
        }
        public bool AddReceiptDetail(int receiptId, int menuId, int quantity, int discount)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@receiptId";
            name[1] = "@menuId";
            name[2] = "@quantity";
            name[3] = "@discount";
            values[0] = receiptId;
            values[1] = menuId;
            values[2] = quantity;
            values[3] = discount;
            return Execute("sp_AddReceiptDetail", name, values, parameter);
        }
        public bool TablePayment(int tableId, int receiptId, double totalPayment, string accountId)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            name[1] = "@receiptId";
            name[2] = "@totalPayment";
            name[3] = "@accountId";
            values[0] = tableId;
            values[1] = receiptId;
            values[2] = totalPayment;
            values[3] = accountId;
            return Execute("sp_TablePayment", name, values, parameter);
        }
        public DataTable LoadMenuListOfTable_rpt(int tableId, int receiptId, string outTime)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            name[1] = "@receiptId";
            name[2] = "@outTime";
            values[0] = tableId;
            values[1] = receiptId;
            values[2] = outTime;
            return LoadDataParameter("sp_LoadMenuListOfTable_rpt", name, values, parameter);
        }
        public bool UpdatePrintedReceipt(int receiptId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@receiptId";
            values[0] = receiptId;
            return Execute("sp_UpdatePrintedReceipt", name, values, parameter);
        }
        public List<ReceiptModel> LoadReceiptToBePrinted()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_LoadReceiptToBePrinted"));
            return JsonConvert.DeserializeObject<List<ReceiptModel>>(json);
        }
    }
}
