using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Twithdraw
{
    public string Wdno { get; set; } = null!;

    public string? EmpId { get; set; }

    public DateTime? Wddatetime { get; set; }

    public string? ProjectId { get; set; }

    public string? Drawer { get; set; }

    public string? Dnremark { get; set; }
}
