using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class CrewDetailsResponse : BaseCrew
{
    public int? CreatedBy { get; set; }
    public List<CrewMovieModel> Movies { get; set; }
}
