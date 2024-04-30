using MovieReviewSite.Core.Models.Comment.Requests;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Models.Review.ModelViews;

public class ReviewDetailsModelView
{
    public ReviewDetails Review { get; set; }
    public CommentRequest AddedComment { get; set; }
}
 
