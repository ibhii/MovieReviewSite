namespace MovieReviewSite.Core.Models.Tag.Requests;

public class AddTagFromReviewRequest : RemoveTagFromReviewRequest
{
    public string? NewTag { get; set; }
    public int AddedBy { get; set; }
}
