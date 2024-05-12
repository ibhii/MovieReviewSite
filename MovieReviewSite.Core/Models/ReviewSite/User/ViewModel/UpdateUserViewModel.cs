using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.Core.Models.User.Response;

namespace MovieReviewSite.Core.Models.User.ViewModel;

public class UpdateUserViewModel
{
    public UserModelDetails User { get; set; }
    public UpdateUserRequest DTO { get; set; }
}
