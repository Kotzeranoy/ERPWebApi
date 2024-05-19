using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tproject
{
    public string ProjectId { get; set; } = null!;

    public string? PartnerId { get; set; }

    public string? ProjectParent { get; set; }

    public string? EmpId { get; set; }

    public string? ProjectLocation { get; set; }

    public DateOnly? ProjectCreate { get; set; }

    public string? ProjectContactNo { get; set; }

    public DateOnly? ProjectContactDate { get; set; }

    public decimal? ProjectContactValue { get; set; }

    public DateOnly? ProjectBiddingDate { get; set; }

    public decimal? ProjectBiddingValue { get; set; }

    public DateOnly? ProjectCommitDate { get; set; }

    public decimal? ProjectCommitValue { get; set; }

    public DateOnly? ProjectBudgetDate { get; set; }

    public decimal? ProjectBudgetValue { get; set; }

    public string? ProjectTelephone { get; set; }

    public string? ProjectEmail { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual Tpartner? Partner { get; set; }

    public virtual ICollection<TgoodReceipt> TgoodReceipts { get; set; } = new List<TgoodReceipt>();

    public virtual ICollection<TprojectPeriod> TprojectPeriods { get; set; } = new List<TprojectPeriod>();

    public virtual ICollection<TpurchaseOrder> TpurchaseOrders { get; set; } = new List<TpurchaseOrder>();

    public virtual ICollection<TpurchaseRequest> TpurchaseRequests { get; set; } = new List<TpurchaseRequest>();
}
