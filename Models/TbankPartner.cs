using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TbankPartner
{
    public string? BankId { get; set; }

    public string? PartnerId { get; set; }

    public string? AccountNo1 { get; set; }

    public string? AccounName { get; set; }

    public string? AccountDescription { get; set; }

    public string? AccountBranch { get; set; }

    public virtual Tbank? Bank { get; set; }

    public virtual Tpartner? Partner { get; set; }
}
