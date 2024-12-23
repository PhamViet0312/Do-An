using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TblAdminMenu
{
    public int AdminMenuId { get; set; }

    public string? ItemName { get; set; }

    public string? Alias { get; set; }

    public int? ItemLevel { get; set; }

    public int? ParentLevel { get; set; }

    public int? ItemOrder { get; set; }

    public string? ItemTarget { get; set; }

    public string? Areaname { get; set; }

    public string? ControllerName { get; set; }

    public string? ActionName { get; set; }

    public string? Icon { get; set; }

    public string? IdName { get; set; }

    public bool? IsActive { get; set; }
}
