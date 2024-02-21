using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Comment;

public class CommentBase
{
    public int Id { get; set; }
    public BaseUser? User { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedOn { get; set; }
}
