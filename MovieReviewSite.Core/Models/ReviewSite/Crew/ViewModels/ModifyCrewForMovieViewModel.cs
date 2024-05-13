using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Movie;

namespace MovieReviewSite.Core.Models.Crew.ViewModels;

public class ModifyCrewForMovieViewModel
{
    public MovieBase? Movie { get; set; }
    public List<BaseCrew>? AllCrew { get; set; }
    public List<BaseCrewWithType>? MovieCrew { get; set; }
    public List<BaseIdTitleModel>? CrewType  { get; set; }
    public CrewMovieRequest? DTO { get; set; } = new CrewMovieRequest();
}
