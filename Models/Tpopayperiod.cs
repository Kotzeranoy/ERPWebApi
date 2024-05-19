using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tpopayperiod
{
    public string? Pono { get; set; }

    public int? Popayperiod { get; set; }

    public decimal? PopayValue { get; set; }

    public int? Popaymethod { get; set; }

    public virtual TpurchaseOrder? PonoNavigation { get; set; }
}
