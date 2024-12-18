using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TbActor
{
    public int ActorId { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Biography { get; set; }

    public string? ProfileImage { get; set; }

    public bool? IsActive { get; set; }
}
