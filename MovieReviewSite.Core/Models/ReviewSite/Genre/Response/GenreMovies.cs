using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Models.Genre.Response;

public class GenreMovies 
{
    public string? GenreTitle  { get; set; }
    public List<Movies>? MoviesList { get; set; }
}
