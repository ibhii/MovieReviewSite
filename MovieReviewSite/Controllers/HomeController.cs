using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Models;

namespace MovieReviewSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieBaseService _movieService;

    public HomeController(ILogger<MovieController> logger,IMovieBaseService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }
    public IActionResult Movies()
    {
        throw new NotImplementedException();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

}
