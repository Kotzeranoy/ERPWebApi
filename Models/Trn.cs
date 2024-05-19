using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Trn
{
    public string Rnno { get; set; } = null!;

    public string? Dnno { get; set; }

    public string? EmpId { get; set; }

    public DateTime? Rndatetime { get; set; }

    public string? ProjectOrigin { get; set; }

    public string? ProjectDestination { get; set; }

    public string? Recipient { get; set; }

    public string? Dnremark { get; set; }
}
