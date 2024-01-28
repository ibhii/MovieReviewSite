using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Review;

public class ReviewBase
{
    public int Id { get; set; }
    public BaseUser? User { get; set; }
}
