namespace MovieReviewSite.Core.Models;

public class MovieList
{
    public int Id { get; set; }
    public string? MovieName { get; set; }
    public DateTimeOffset? ReleaseDate { get; set; }
    public int? Duration { get; set; }
    public int? Rating { get; set; }
    public string? AgeRating { get; set; }
    public string? Image { get; set; }
}
