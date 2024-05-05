using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class MoviesForCrew : Movies
{
    public string? FullName { get; set; }
    public List<CrewMovieModel> Movies { get; set; }
}
