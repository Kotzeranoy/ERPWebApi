using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TempStatus
{
    public string EmpStatusId { get; set; } = null!;

    public string? EmpStatusName { get; set; }

    public string? EmpStatusDescription { get; set; }

    public virtual ICollection<Temployee> Temployees { get; set; } = new List<Temployee>();
}
