using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Comment.Requests;

public class CommentRequest : IBaseModel
{
    public int ReviewId { get; set; }
    public string? Comment { get; set; }
    public int? UserId { get; set; }
}
