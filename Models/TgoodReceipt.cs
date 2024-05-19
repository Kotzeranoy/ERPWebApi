using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TgoodReceipt
{
    public string Grno { get; set; } = null!;

    public string? Pono { get; set; }

    public DateTime? Grdate { get; set; }

    public string? Dono { get; set; }

    public DateOnly? Dodate { get; set; }

    public string? ProjectId { get; set; }

    public string? EmpId { get; set; }

    public string? PartnerId { get; set; }

    public decimal? Grsubtotal { get; set; }

    public int? Grvat { get; set; }

    public decimal? GrvatValue { get; set; }

    public decimal? GrspecialDiscount { get; set; }

    public decimal? Grtotal { get; set; }

    public string? Grremark { get; set; }

    public int? GrpayTerm { get; set; }

    public int? GrpayMethod { get; set; }

    public int? GrpayCreditDate { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual Tpartner? Partner { get; set; }

    public virtual TpurchaseOrder? PonoNavigation { get; set; }

    public virtual Tproject? Project { get; set; }
}
