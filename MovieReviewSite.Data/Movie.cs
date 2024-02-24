using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Movie
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? RealeaseDate { get; set; }

    public bool? IsVisible { get; set; }

    public int? StreamId { get; set; }

    public int? AgeRateId { get; set; }

    public string? Synopsis { get; set; }

    public byte[]? Poster { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public int? Duration { get; set; }

    public int? TypeId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Status? Status { get; set; }
}
