using MovieReviewSite.Core.Enums;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class CrewMovieModel : BaseCrew
{
    public int? MovieId { get; set; }
    public string? MovieName { get; set; }
    public BaseIdTitleModel? CrewType { get; set; }
}
