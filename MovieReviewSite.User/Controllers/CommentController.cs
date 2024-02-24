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
    public async Task<List<CommentBase>> GetCommentsByReviewId([FromQuery]int id)
    {
        return await _repository.GetCommentsByReviewId(id);
    }

    [HttpGet("[action]")]
    public async Task<CommentBase?> GetCommentById([FromQuery]int id)
    {
        return await _repository.GetCommentById(id);
    }

    [HttpPost("[action]")]
    public async Task AddComment([FromBody]CommentRequest dto)
    {
        await _repository.AddComment(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteComment([FromBody]int id)
    {
        await _repository.DeleteComment(id);
    }

}
