using MovieReviewSite.Core.Enums;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class CrewMovieModel
{
    public int? MovieId { get; set; }
    public string? MovieName { get; set; }
    public int? CrewType { get; set; }
}
