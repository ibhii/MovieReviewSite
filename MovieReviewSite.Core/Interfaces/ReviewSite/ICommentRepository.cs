using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface ICommentRepository : IBaseRepository
{
    Task<List<BaseComment>> GetAllCommentsList();
    Task<List<BaseComment>> GetCommentsByReviewId(int id);
    Task<BaseComment?> GetCommentById(int id);
    Task AddComment(int id,CommentRequest dto);
    Task DeleteComment(int id,int userId);
    Task<List<BaseComment>> GetCommentsByUserId(int id);

}
