using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Review;

public class ReviewBase : BaseModel
{
    public BaseUserModel? User { get; set; }
    public string? Title { get; set; }
}
