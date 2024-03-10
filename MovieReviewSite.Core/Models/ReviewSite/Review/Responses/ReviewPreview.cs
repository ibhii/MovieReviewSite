using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MovieReviewSite.Core.Models.Review.Responses;

public class ReviewPreview : ReviewBase
{
    public string? Review { get; set; }
    public BaseIdTitleModel Movie { get; set; }
    public int CommentsCount { get; set; }
    public double? Score { get; set; }
    public int? LikesCount { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastModified { get; set; }
}
