using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.Crew.Requests;

public class NewCrewRequest
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? BirthDate { get; set; }
}
