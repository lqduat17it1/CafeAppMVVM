using System;
using System.Collections.Generic;

namespace CafeMVVM.Models;

public partial class TableAreaModel
{
    public int AreaId { get; set; }

    public string? AreaName { get; set; }

    public int TableId { get; set; }

    public string? TableName { get; set; }

    public string? TableStatus { get; set; }

    public int? NumberOfTables { get; set; }

    public int ReceiptId { get; set; }
}
