using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
