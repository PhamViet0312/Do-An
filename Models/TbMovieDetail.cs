using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TbMovieDetail
{
    public int MovieDetailId { get; set; }

    public int? MovieId { get; set; }

    public string? Director { get; set; }

    public string? Writer { get; set; }

    public string? Stars { get; set; }

    public string? Genres { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? RunTime { get; set; }

    public string? Mmparating { get; set; }

    public virtual TbMovie? Movie { get; set; }
}
