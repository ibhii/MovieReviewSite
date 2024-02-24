using MovieReviewSite.Core.Models.Comment;

namespace MovieReviewSite.Core.Models.Review.Responses;

public class ReviewDetails : ReviewPreview
{
    public List<int>? Tags { get; set; }
    public List<CommentBase>? Comments { get; set; }
}
