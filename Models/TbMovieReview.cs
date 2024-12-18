using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TbMovieReview
{
    public int MovieReviewId { get; set; }

    public int MovieId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? Rating { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbMovie Movie { get; set; } = null!;
}
