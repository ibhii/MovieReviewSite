using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRepository _movieRepository;

    public MovieController(ILogger<HomeController> logger,IMovieRepository movieRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public async Task<List<MovieList>> GetMoviesList()
    {
        return await _movieRepository.GetMovieList();
    }
    
    [HttpGet("[action]/{id}")]
    public async Task<MovieDetail?> GetMovieDetail(int id)
    {
        return await _movieRepository.GetMovieDetails(id);
    }
}
