using MovieReviewSite.Core.Models.Role;

namespace MovieReviewSite.Core.Models.User;

public class BaseUser
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public BaseRole? Role { get; set; }
}
