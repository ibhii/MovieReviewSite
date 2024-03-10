using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class CrewWithMoviesResponse : BaseCrew
{
    public List<CrewMovieModel> Movies { get; set; }
}
