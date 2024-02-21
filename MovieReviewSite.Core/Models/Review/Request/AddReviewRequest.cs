namespace MovieReviewSite.Core.Models.Review.Request;

public class AddReviewRequest
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public int Title { get; set; }
    public string? Review { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public int GivenRate { get; set; }
}
