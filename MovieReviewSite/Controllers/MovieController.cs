using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;

namespace MovieReviewSite.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieService _movieService;

    public MovieController(ILogger<HomeController> logger,IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<List<MovieList>> GetMoviesList()
    {
        return await _movieService.GetMovieList();
    }

    [HttpGet]
    public async Task<MovieDetail?> GetMovieDetail(int id)
    {
        return await _movieService.GetMovieDetails(id);
    }
}
