using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class Tunit
{
    public string UnitId { get; set; } = null!;

    public string? UnitName { get; set; }

    public string? UnitType { get; set; }

    public virtual ICollection<Tmaterial> Tmaterials { get; set; } = new List<Tmaterial>();
}
