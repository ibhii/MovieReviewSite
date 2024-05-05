using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class MoviesForCrewDetails : Movies 
{
    public BaseIdTitleModel? CrewType { get; set; }
}
