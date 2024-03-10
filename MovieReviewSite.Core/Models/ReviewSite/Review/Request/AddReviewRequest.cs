using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Review.Request;

public class AddReviewRequest : IBaseModel
{
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Review { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public int? GivenRate { get; set; }
}
