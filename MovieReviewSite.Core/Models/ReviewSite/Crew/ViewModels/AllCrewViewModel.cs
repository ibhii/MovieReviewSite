using System.Reflection.Metadata.Ecma335;
using MovieReviewSite.Core.Models.Crew.Requests;

namespace MovieReviewSite.Core.Models.Crew.ViewModels;

public class AllCrewViewModel
{
    public List<BaseCrew>? Crew { get; set; }
    public AllCrewListRequest DTO { get; set; }
}
