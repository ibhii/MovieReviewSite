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
    public async Task<List<ReviewPreview>> GetReviewByMovieId(int id)
    {
        return await _repository.GetReviewsByMovieId(id);
    }

    [HttpGet("[action]")]
    public async Task<ReviewDetailes> GetReviewById(int id)
    {
        return await _repository.GetReviewById(id);
    }

    [HttpPost("[action]")]
    public async Task AddReview(AddReviewRequest dto)
    {
        await _repository.AddReview(dto);
    }

    [HttpPost("[action]")]
    public async Task LikeReview(int id)
    {
        await _repository.LikeReview(id);
    }

    [HttpPut("[action]")]
    public async Task UpdateReview(UpdateReviewRequest dto)
    {
        await _repository.UpdateReview(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteReview(int id)
    {
        await _repository.DeleteReview(id);
    }

}
