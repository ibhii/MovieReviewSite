using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Models;

namespace MovieReviewSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRepository _movieRepository;


    public HomeController(ILogger<HomeController> logger,IMovieRepository movieRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }

    public async Task<IActionResult> GetAllMoviesList()
    {
        var movieList = await _movieRepository.GetMovieList();
        return View(movieList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    

}
