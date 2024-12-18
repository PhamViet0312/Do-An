using System;
using System.Collections.Generic;

namespace Do_An.Models;

public partial class TbMovie
{
    public int MovieId { get; set; }

    public int? CategoryMovieId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Image { get; set; }

    public int? Since { get; set; }

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int? Duration { get; set; }

    public int? Rating { get; set; }

    public string? Language { get; set; }

    public string? Poster { get; set; }

    public string? TrailerUrl { get; set; }

    public bool IsActive { get; set; }

    public virtual TbCategoryMovie? CategoryMovie { get; set; }

    public virtual ICollection<TbMovieDetail> TbMovieDetails { get; set; } = new List<TbMovieDetail>();

    public virtual ICollection<TbMovieReview> TbMovieReviews { get; set; } = new List<TbMovieReview>();
}
