using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Comment.Requests;

public class CommentRequest
{
    public int ReviewId { get; set; }
    public string? Comment { get; set; }
    public BaseUser? User { get; set; }
}
