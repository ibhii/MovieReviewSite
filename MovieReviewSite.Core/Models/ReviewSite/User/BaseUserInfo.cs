namespace MovieReviewSite.Core.Models.User;

public class BaseUserInfo : BaseModel
{
    public string? Name { get; set; }
    public int RoleCode { get; set; }
    public string UserName { get; set; }
}
