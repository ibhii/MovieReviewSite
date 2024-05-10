namespace MovieReviewSite.Core.Models.User.Response;

public class UserModelDetails : BaseUserModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string? Email { get; set; }
}
