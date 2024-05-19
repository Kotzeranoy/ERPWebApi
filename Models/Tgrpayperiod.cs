using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tgrpayperiod
{
    public string? Grno { get; set; }

    public int? Grpayperiod { get; set; }

    public decimal? GrpayValue { get; set; }

    public int? Grpaymethod { get; set; }

    public virtual TgoodReceipt? GrnoNavigation { get; set; }
}
