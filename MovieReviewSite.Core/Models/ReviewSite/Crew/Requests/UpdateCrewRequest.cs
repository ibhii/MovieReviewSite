namespace MovieReviewSite.Core.Models.Crew.Requests;

public class UpdateCrewRequest
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? IsAlive { get; set; }
    public DateTime DeathDate { get; set; }
}
