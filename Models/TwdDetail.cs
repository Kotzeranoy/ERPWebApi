using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TwdDetail
{
    public string? Wdno { get; set; }

    public int? ItemNo { get; set; }

    public string? MatCode { get; set; }

    public decimal? Quantity { get; set; }

    public string? UnitId { get; set; }

    public string? Remark { get; set; }
}
