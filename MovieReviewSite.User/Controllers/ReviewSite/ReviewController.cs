﻿using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.ModelViews;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Controllers.ReviewSite;

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

    [HttpPost("[action]/{id}")]
    public async Task AddReview(int id,[FromBody]AddReviewRequest dto)
    {
        await _repository.AddReview(dto,id);
    }

    [HttpPut("[action]")]
    public async Task LikeReview([FromBody]int id)
    {
        await _repository.LikeReview(id);
    }

    [HttpPut("[action]")]
    public async Task UpdateReview([FromBody]UpdateReviewRequest dto)
    {
        await _repository.UpdateReview(dto);
    }

    [HttpPost("[action]/{id}")]
    public async Task DeleteReview(int id)
    {
        await _repository.DeleteReview(id);
    }

    /// <summary>
    /// gets the average score for a movie from all reviews
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<double?> GetAverageScore([FromQuery] int id)
    {
        return await _repository.GetScoreAverageByMovieId(id);
    }
    
    [Route("[action]/{id}")]
    public async Task<ActionResult> AddReviewView(int id)
    {
        return View();
    }
    
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetReviewByMovieIdView(int id)
    {
        var reviews = await _repository.GetReviewsByMovieId(id);
        return View(reviews);
    }
    
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetReviewDetailsView(int id)
    {
        var review = await _repository.GetReviewById(id);
        var model = new ReviewDetailsModelView
        {
            Review = review
        };
        return View(model);
    }

}
