using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tbank
{
    public string BankId { get; set; } = null!;

    public string? BankName { get; set; }

    public string? BankDescription { get; set; }

    public string? BankAddress { get; set; }

    public string? BankAbbreviation { get; set; }
}
