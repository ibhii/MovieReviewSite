namespace MovieReviewSite.Core.Models.Password.Requests;

public class UpdatePasswordRequest
{
    public int ModifierId { get; set; }
    public string? NewPassword { get; set; }
    public string? CurrentPassword { get; set; }
}
