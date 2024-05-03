namespace MovieReviewSite.Core.Models.Password.Requests;

public class UpdatePasswordRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? NewPassword { get; set; }
    public string? CurrentPassword { get; set; }
}
