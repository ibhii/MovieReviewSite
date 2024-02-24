namespace MovieReviewSite.Core.Models.Review.Responses;

public class ReviewPreview : ReviewBase
{
    public string? Review { get; set; }
    public int CommentsCount { get; set; }
    public double? GivenRate { get; set; }
    public int? LikesCount { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastModified { get; set; }
}
