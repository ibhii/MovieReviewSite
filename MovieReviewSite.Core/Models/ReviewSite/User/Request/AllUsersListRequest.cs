using MovieReviewSite.Core.Enums;

namespace MovieReviewSite.Core.Models.User.Request;

public class AllUsersListRequest
{
    public string? Search { get; set; }
    public CreatedOnOrder CreatedOnOrder { get; set; }
    public Roles RoleFilter { get; set; }
}
