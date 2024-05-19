using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TpurchaseRequest
{
    public string Prno { get; set; } = null!;

    public DateTime? Prdate { get; set; }

    public string? ProjectId { get; set; }

    public string? EmpId { get; set; }

    public string? PartnerId { get; set; }

    public decimal? Prsubtotal { get; set; }

    public int? Prvat { get; set; }

    public decimal? PrvatValue { get; set; }

    public decimal? PrspecialDiscount { get; set; }

    public decimal? Prtotal { get; set; }

    public string? Prremark { get; set; }

    public int? PrpayTerm { get; set; }

    public int? PrpayMethod { get; set; }

    public int? PrpayCreditDate { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual Tpartner? Partner { get; set; }

    public virtual Tproject? Project { get; set; }
}
