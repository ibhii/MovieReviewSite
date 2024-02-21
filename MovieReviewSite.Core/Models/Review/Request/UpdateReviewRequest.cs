using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.Review.Request;

public class UpdateReviewRequest
{
    public int Id { get; set; }
    public string? Review { get; set; }
    public string? Title { get; set; }
}
