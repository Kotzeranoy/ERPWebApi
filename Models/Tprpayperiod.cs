using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tprpayperiod
{
    public string? Prno { get; set; }

    public int? Prpayperiod { get; set; }

    public decimal? PrpayValue { get; set; }

    public int? Prpaymethod { get; set; }

    public virtual TpurchaseRequest? PrnoNavigation { get; set; }
}
