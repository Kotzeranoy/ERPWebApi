using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tunitconvert
{
    public string? MatCode { get; set; }

    public int? ConvertNo { get; set; }

    public string? UnitBase { get; set; }

    public decimal? UnitBaseAmount { get; set; }

    public string? UnitConvert { get; set; }

    public decimal? UnitConvertAmount { get; set; }

    public virtual Tmaterial? MatCodeNavigation { get; set; }

    public virtual Tunit? UnitBaseNavigation { get; set; }

    public virtual Tunit? UnitConvertNavigation { get; set; }
}
