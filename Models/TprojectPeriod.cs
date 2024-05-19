using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TprojectPeriod
{
    public string ProjectPeriodId { get; set; } = null!;

    public string? ProjectId { get; set; }

    public string? ContactNo { get; set; }

    public decimal? ContactValue { get; set; }

    public int? PeriodAmount { get; set; }

    public decimal? Advance { get; set; }

    public decimal? Retention { get; set; }

    public virtual Tproject? Project { get; set; }
}
