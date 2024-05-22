using MovieReviewSite.Core.Enums;

namespace MovieReviewSite.Core.Models.Movie.Request;

public class MovieListRequest
{
    public string? Search { get; set; } = "";
    public ReleasedOnOrder? Order { get; set; } = ReleasedOnOrder.ReleasedOnAsc;

}
