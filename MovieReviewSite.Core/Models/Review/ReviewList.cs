using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Review;

public class ReviewList : ReviewBase
{
    public string? Title { get; set; }
    public string? Review { get; set; }
    public int CommentsCount { get; set; }
    public int GivenRate { get; set; }
    public int? LikesCount { get; set; }
}
