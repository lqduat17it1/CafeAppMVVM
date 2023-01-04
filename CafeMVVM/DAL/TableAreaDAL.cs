using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeMVVM.Models;

namespace CafeMVVM.DAL
{
    public class TableAreaDAL : BaseDAL
    {
        public List<TableAreaModel> LoadArea()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_LoadArea"));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public List<TableAreaModel> LoadTableByArea(int areaId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            values[0] = areaId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadTableByArea", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public List<TableAreaModel> LoadAreaList()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_LoadAreaList"));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public bool AddArea(string areaName)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaName";
            values[0] = areaName;
            return Execute("sp_AddArea", name, values, parameter);
        }

        public bool DeleteArea(int areaId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            values[0] = areaId;
            return Execute("sp_DeleteArea", name, values, parameter);
        }

        public List<TableAreaModel> TableList(int areaId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            values[0] = areaId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_TableList", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public bool AddTable(string tableName, int areaId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableName";
            values[0] = tableName;
            name[1] = "@areaId";
            values[1] = areaId;
            return Execute("sp_AddTable", name, values, parameter);
        }

        public bool DeleteTable(int ban)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            values[0] = ban;
            return Execute("sp_DeleteTable", name, values, parameter);
        }

        public bool EditTable(int tableId, string tableName)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            name[1] = "@tableName";
            values[0] = tableId;
            values[1] = tableName;
            return Execute("sp_EditTable", name, values, parameter);
        }

        public bool DeleteReceiptDetail(int receiptId, int tableId, int discount)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@receiptId";
            name[1] = "@menuId";
            name[2] = "@discount";
            values[0] = receiptId;
            values[1] = tableId;
            values[2] = discount;
            return Execute("sp_DeleteReceiptDetail", name, values, parameter);
        }

        public bool DeleteReceiptWhenOutOfMenu(int receiptId, int tableId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@receiptId";
            name[1] = "@tableId";
            values[0] = receiptId;
            values[1] = tableId;
            return Execute("sp_DeleteReceiptWhenOutOfMenu", name, values, parameter);
        }

        public List<TableAreaModel> LoadEmptyTable(int areaId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            values[0] = areaId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadEmptyTable", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public List<TableAreaModel> LoadInUseTable(int areaId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            values[0] = areaId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadInUseTable", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public bool ChangeTable(int newTableId, int oldTableId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@newTableId";
            name[1] = "@oldTableId";
            values[0] = newTableId;
            values[1] = oldTableId;
            return Execute("sp_ChangeTable", name, values, parameter);
        }

        public List<TableAreaModel> LoadMergeTable(int areaId, int tableId)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@areaId";
            name[1] = "@tableId";
            values[0] = areaId;
            values[1] = tableId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadMergeTable", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }

        public List<ReceiptModel> LoadMergeTableReceiptDetail(int tableId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            values[0] = tableId;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_LoadMergeTableReceiptDetail", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ReceiptModel>>(json);
        }

        public bool DeleteMergeTableReceipt(int tableId)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tableId";
            values[0] = tableId;
            return Execute("sp_DeleteMergeTableReceipt", name, values, parameter);
        }

        public List<TableAreaModel> AreaListHasEmptyTable()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_AreaListHasEmptyTable"));
            return JsonConvert.DeserializeObject<List<TableAreaModel>>(json);
        }
    }
}
