using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Models.User.ViewModel;

public class AllUsersViewModel
{
    public List<BaseUserModel> User { get; set; }
    public AllUsersListRequest DTO { get; set; }
}
