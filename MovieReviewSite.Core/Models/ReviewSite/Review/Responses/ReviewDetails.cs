using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Tag;

namespace MovieReviewSite.Core.Models.Review.Responses;

public class ReviewDetails : ReviewPreview
{
    public List<BaseTag> Tags { get; set; }
    public List<BaseComment>? Comments { get; set; }
}
