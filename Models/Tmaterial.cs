using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tmaterial
{
    public string MatCode { get; set; } = null!;

    public string? CatCode { get; set; }

    public string? MatName { get; set; }

    public string? MatDescription { get; set; }

    public string? UnitId { get; set; }

    public string? EmpId { get; set; }

    public DateOnly? MatCreate { get; set; }

    public bool? Matischeck { get; set; }

    public virtual Tcategory? CatCodeNavigation { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual Tunit? Unit { get; set; }
}
