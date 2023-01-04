using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Models;

public partial class StatisticModel
{
    public string MenuName { get; set; }

    public int ReceiptID { get; set; }

    public string AreaName { get; set; }

    public int Quantity { get; set; }

    public object Price { get; set; }

    public int Discount { get; set; }

    public string TableName { get; set; }

    public object TotalPayment { get; set; }

    public object CreatedDate { get; set; }

    public string CreatedTime { get; set; }

}
