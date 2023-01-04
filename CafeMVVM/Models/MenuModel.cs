using System;
using System.Collections.Generic;

namespace CafeMVVM.Models;

public partial class MenuModel
{
    public int Mcid { get; set; }

    public string? Mcname { get; set; }

    public int MenuId { get; set; }

    public string? MenuName { get; set; }

    public double? Price { get; set; }

    public int? Discount { get; set; }

}
