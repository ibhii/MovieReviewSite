using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Controllers;

[Route("[controller]")]
[ApiController]
public class ReviewController : Controller
{
    private readonly IReviewRepository _repository;

    public ReviewController(IReviewRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("[action]")]
    public async Task<List<ReviewBase>> GetAllReview()
    {
        return await _repository.GetAllReviews();
    }

    [HttpGet("[action]")]
    public async Task<List<ReviewPreview>> GetReviewByMovieId([FromQuery]int id)
    {
        return await _repository.GetReviewsByMovieId(id);
    }

    [HttpGet("[action]")]
    public async Task<ReviewDetails> GetReviewById([FromQuery]int id)
    {
        return await _repository.GetReviewById(id);
    }

    [HttpPost("[action]")]
    public async Task AddReview([FromBody]AddReviewRequest dto)
    {
        await _repository.AddReview(dto);
    }

    [HttpPut("[action]")]
    public async Task LikeReview([FromQuery]int id)
    {
        await _repository.LikeReview(id);
    }

    [HttpPut("[action]")]
    public async Task UpdateReview([FromBody]UpdateReviewRequest dto)
    {
        await _repository.UpdateReview(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteReview([FromBody]int id)
    {
        await _repository.DeleteReview(id);
    }

}
