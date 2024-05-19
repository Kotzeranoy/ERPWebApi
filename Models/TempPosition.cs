using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TempPosition
{
    public string EmpPositionId { get; set; } = null!;

    public string? EmpPositionName { get; set; }

    public string? EmpPostionDescription { get; set; }

    public virtual ICollection<Temployee> Temployees { get; set; } = new List<Temployee>();
}
