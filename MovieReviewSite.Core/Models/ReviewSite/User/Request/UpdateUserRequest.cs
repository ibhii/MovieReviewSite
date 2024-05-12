using MovieReviewSite.Core.Models.Password.Requests;

namespace MovieReviewSite.Core.Models.User.Request;

public class UpdateUserRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public int ModifierId { get; set; }
    public int ModifierRoleCode { get; set; }
}
