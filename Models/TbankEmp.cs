using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TbankEmp
{
    public string? EmpId { get; set; }

    public string? BankId { get; set; }

    public string? AccountNo { get; set; }

    public string? AccounName { get; set; }

    public string? AccountDescription { get; set; }

    public string? AccountBranch { get; set; }

    public virtual Tbank? Bank { get; set; }

    public virtual Temployee? Emp { get; set; }
}
