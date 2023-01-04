using System;
using System.Collections.Generic;

namespace CafeMVVM.Models;

public partial class ReceiptModel
{
    public int ReceiptId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public double? TotalPayment { get; set; }

    public double? TotalReceipt { get; set; }

    public int? TableId { get; set; }

    public string? TableName { get; set; }

    public int? ReceiptStatus { get; set; }

    public int? PrintReceipt { get; set; }

    public string? CreatedTime { get; set; }

    public string? AccountId { get; set; }

    public int Rdid { get; set; }

    public int? MenuId { get; set; }

    public string? MenuName { get; set; }

    public int? Quantity { get; set; }

    public int? Discount { get; set; }

    public double? Price { get; set; }

    public string? FullName { get; set; }

    public string? AreaName { get; set; }

    public string? OutTime { get; set; }

}
