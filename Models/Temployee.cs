using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Temployee
{
    public string EmpId { get; set; } = null!;

    public string? EmpFirstname { get; set; }

    public string? EmpLastname { get; set; }

    public string? EmpOthername { get; set; }

    public string? EmpUsername { get; set; }

    public string? EmpPassword { get; set; }

    public DateOnly? EmpDateStart { get; set; }

    public string? EmpAddress { get; set; }

    public string? EmpEmail { get; set; }

    public string? EmpTelephone { get; set; }

    public string? EmpDescription { get; set; }

    public string? EmpStatusId { get; set; }

    public string? EmpPositionId { get; set; }

    public byte[]? EmpImage { get; set; }

    public virtual TempPosition? EmpPosition { get; set; }

    public virtual TempStatus? EmpStatus { get; set; }

    public virtual ICollection<Tcategory> Tcategories { get; set; } = new List<Tcategory>();

    public virtual ICollection<TgoodReceipt> TgoodReceipts { get; set; } = new List<TgoodReceipt>();

    public virtual ICollection<Tmaterial> Tmaterials { get; set; } = new List<Tmaterial>();

    public virtual ICollection<Tproject> Tprojects { get; set; } = new List<Tproject>();

    public virtual ICollection<TpurchaseOrder> TpurchaseOrders { get; set; } = new List<TpurchaseOrder>();

    public virtual ICollection<TpurchaseRequest> TpurchaseRequests { get; set; } = new List<TpurchaseRequest>();
}
