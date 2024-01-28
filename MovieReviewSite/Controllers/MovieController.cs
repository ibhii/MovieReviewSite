using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Models;

namespace MovieReviewSite.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    public async Task<List<MovieList>>Index()
    {
        return  new List<MovieList>() ;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
