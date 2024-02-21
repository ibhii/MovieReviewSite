using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface ICommentRepository : IBaseRepository
{
    Task<List<CommentBase>> GetAllCommentsList();
    Task<List<CommentBase>> GetCommentsByReviewId(int id);
    Task<CommentBase?> GetCommentById(int id);
    Task AddComment(CommentRequest dto);
    Task DeleteComment(int id);

}
