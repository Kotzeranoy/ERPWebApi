using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TpurchaseOrder
{
    public string Pono { get; set; } = null!;

    public string? Prno { get; set; }

    public DateTime? Podate { get; set; }

    public string? ProjectId { get; set; }

    public string? EmpId { get; set; }

    public string? PartnerId { get; set; }

    public decimal? Posubtotal { get; set; }

    public int? Povat { get; set; }

    public decimal? PovatValue { get; set; }

    public decimal? PospecialDiscount { get; set; }

    public decimal? Pototal { get; set; }

    public string? Poremark { get; set; }

    public int? PopayTerm { get; set; }

    public int? PopayMethod { get; set; }

    public int? PopayCreditDate { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual Tpartner? Partner { get; set; }

    public virtual Tproject? Project { get; set; }

    public virtual ICollection<TgoodReceipt> TgoodReceipts { get; set; } = new List<TgoodReceipt>();
}
