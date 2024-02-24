using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Movie.Responses;

public class MovieList : IBaseModel
{
    public int Id { get; set; }
    public string? MovieName { get; set; }
    public DateTimeOffset? ReleaseDate { get; set; }
    public int? Duration { get; set; }
    public int? Rating { get; set; }
    public int? AgeRating { get; set; }
    public byte[]? Image { get; set; }
}
