using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Models.Movie;

public class MovieDetail
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
    public List<ReviewList> ReviewList { get; set; }
}
