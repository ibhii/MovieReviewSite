using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;

namespace MovieReviewSite.Controllers;

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
    public async Task<List<CommentBase>> GetAllCommentsList()
    {
        return await _repository.GetAllCommentsList();
    }

    [HttpGet("[action]")]
    public async Task<List<CommentBase>> GetCommentsByReviewId(int id)
    {
        return await _repository.GetCommentsByReviewId(id);
    }

    [HttpGet("[action]")]
    public async Task<CommentBase?> GetCommentById(int id)
    {
        return await _repository.GetCommentById(id);
    }

    [HttpPost("[action]")]
    public async Task AddComment(CommentRequest dto)
    {
        await _repository.AddComment(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteComment(int id)
    {
        await _repository.DeleteComment(id);
    }

}
