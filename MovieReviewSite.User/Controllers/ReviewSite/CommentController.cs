using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class CommentController : Controller
{
    private readonly ICommentRepository _repository;

    public CommentController(ICommentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("[action]")]
    public async Task<List<BaseComment>> GetAllCommentsList()
    {
        return await _repository.GetAllCommentsList();
    }

    [HttpGet("[action]")]
    public async Task<List<BaseComment>> GetCommentsByReviewId([FromQuery] int id)
    {
        return await _repository.GetCommentsByReviewId(id);
    }

    [HttpGet("[action]")]
    public async Task<BaseComment?> GetCommentById([FromQuery] int id)
    {
        return await _repository.GetCommentById(id);
    }

    [Authorize]
    [HttpPost("[action]/{id}")]
    public async Task AddComment(int id, [FromBody] CommentRequest dto)
    {
        await _repository.AddComment(id, dto);
    }

    [Authorize]
    [HttpPost("[action]/{id}")]
    public async Task DeleteComment(int id, [FromBody] int userId)
    {
        await _repository.DeleteComment(id, userId);
    }
}
