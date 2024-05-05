using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Models.Crew.ResponseBase;

public class CrewDetails : BaseCrew
{
    public DateTime? CreatedOn{ get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? IsAlive { get; set; }
    public DateTime? DeathDate  { get; set; }
    public List<MoviesForCrewDetails>? MoviesList { get; set; }
}
