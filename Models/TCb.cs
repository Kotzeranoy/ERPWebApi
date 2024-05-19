using System;
using System.Collections.Generic;

namespace ERPWebApi.Models;

public partial class TCb
{
    public string Cbscode { get; set; } = null!;

    public string? Cbsparent { get; set; }

    public int? Cbslevel { get; set; }

    public string? Cbsname { get; set; }

    public string? Cbsdescription { get; set; }

    public virtual ICollection<Tcategory> Tcategories { get; set; } = new List<Tcategory>();
}
