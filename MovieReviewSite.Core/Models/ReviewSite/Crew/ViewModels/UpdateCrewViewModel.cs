using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;

namespace MovieReviewSite.Core.Models.Crew.ViewModels;

public class UpdateCrewViewModel
{
    public CrewDetails? Crew { get; set; }
    public NewCrewRequest? DTO { get; set; }
}
