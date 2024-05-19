using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TdeliveryNote
{
    public string Dnno { get; set; } = null!;

    public string? EmpId { get; set; }

    public DateTime? Dndatetime { get; set; }

    public string? ProjectOrigin { get; set; }

    public string? ProjectDestination { get; set; }

    public string? Deliverer { get; set; }

    public string? DncarId { get; set; }

    public string? CarRegNo { get; set; }

    public string? Dnremark { get; set; }
}
