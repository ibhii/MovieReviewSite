using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Models.User.ViewModel;

public class ChangeUserRoleViewModel
{
    public List<BaseUserModel> Users { get; set; }
    public List<BaseIdTitleModel> Roles { get; set; }
    public UserRole DTO { get; set; }
}
