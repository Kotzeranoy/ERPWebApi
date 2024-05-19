using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tcategory
{
    public string CatCode { get; set; } = null!;

    public string? CatParent { get; set; }

    public int? CatLevel { get; set; }

    public string? CatName { get; set; }

    public string? CatDescription { get; set; }

    public string? EmpId { get; set; }

    public string? Cbscode { get; set; }

    public DateOnly? CatCreate { get; set; }

    public virtual TCb? CbscodeNavigation { get; set; }

    public virtual Temployee? Emp { get; set; }

    public virtual ICollection<Tmaterial> Tmaterials { get; set; } = new List<Tmaterial>();

    public virtual ICollection<Tcategory> SubCategories { get; set; } = new List<Tcategory>();
}
