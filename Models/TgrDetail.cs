using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TgrDetail
{
    public string? Grno { get; set; }

    public int? Gritem { get; set; }

    public string? Pono { get; set; }

    public string? CatCode { get; set; }

    public string? MatCode { get; set; }

    public string? Description { get; set; }

    public decimal? Quantity { get; set; }

    public string? UnitId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Total { get; set; }

    public string? Remark { get; set; }

    public virtual Tcategory? CatCodeNavigation { get; set; }

    public virtual TgoodReceipt? GrnoNavigation { get; set; }

    public virtual Tmaterial? MatCodeNavigation { get; set; }

    public virtual Tunit? Unit { get; set; }
}
