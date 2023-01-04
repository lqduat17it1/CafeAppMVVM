using System;
using System.Collections.Generic;

namespace CafeMVVM.Models;

public partial class AccountModel
{
    public string Username { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
