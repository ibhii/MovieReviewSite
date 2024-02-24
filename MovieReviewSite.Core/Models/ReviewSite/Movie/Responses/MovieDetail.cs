using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Genre;

namespace MovieReviewSite.Core.Models.Movie.Responses;

public class MovieDetail : IBaseModel
{
    public int Id { get; set; }
    public byte[]? Image { get; set; }
    public string?  MovieName { get; set; }
    public string? Synopsis { get; set; }
    public List<string>? Crew { get; set; }
    public List<GenreBase> Genre { get; set; }
    public DateTimeOffset ReleaseDate { get; set; }
    public int Rating { get; set; }
    public int? Duration { get; set; }
}
