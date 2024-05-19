using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tpartner
{
    public string PartnerId { get; set; } = null!;

    public string? PartnerTaxId { get; set; }

    public string? PartnerName { get; set; }

    public string? PartnerOthername { get; set; }

    public string? PartnerAddress { get; set; }

    public string? PartnerZipcode { get; set; }

    public string? PartnerTelephone { get; set; }

    public string? PartnerFax { get; set; }

    public string? PartnerEmail { get; set; }

    public bool? PartnerPayment { get; set; }

    public int? PartnerPayMethod { get; set; }

    public int? PartnerPayCreditDate { get; set; }

    public bool? PartnerReceipts { get; set; }

    public int? PartnerRecMethod { get; set; }

    public int? PartnerRecCreditDate { get; set; }

    public int? PartnerType { get; set; }

    public virtual ICollection<TgoodReceipt> TgoodReceipts { get; set; } = new List<TgoodReceipt>();

    public virtual ICollection<Tproject> Tprojects { get; set; } = new List<Tproject>();

    public virtual ICollection<TpurchaseOrder> TpurchaseOrders { get; set; } = new List<TpurchaseOrder>();

    public virtual ICollection<TpurchaseRequest> TpurchaseRequests { get; set; } = new List<TpurchaseRequest>();
}
