using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TpreiodDetail
{
    public string? ProjectPeriodId { get; set; }

    public string? PeriodItem { get; set; }

    public string? PeriodName { get; set; }

    public decimal? PeriodValue { get; set; }

    public decimal? PeriodAdvance { get; set; }

    public decimal? PreiodRetention { get; set; }

    public decimal? PreiodSubtotal { get; set; }

    public DateOnly? PreiodDate { get; set; }

    public string? PreiodRemark { get; set; }

    public virtual TprojectPeriod? ProjectPeriod { get; set; }
}
