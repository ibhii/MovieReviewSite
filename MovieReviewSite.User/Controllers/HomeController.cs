using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.ViewModels;
using MovieReviewSite.Models;

namespace MovieReviewSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRepository _movieRepository;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger,IMovieRepository movieRepository, IConfiguration config)
    {
        _logger = logger;
        _movieRepository = movieRepository;
        _config = config;
    }

    public async Task<IActionResult> GetAllMoviesList(string? searchString,int sort)
    {
        var movieList = new AllMoviesListVewModel();
        var dto = new MovieListRequest();
        @ViewData["CurrentFilter"] = searchString;
        ViewData["DateSortParam"] = sort;
        dto.Order = (ReleasedOnOrder) sort;
        dto.Search = searchString;
        // @ViewData["CurrentFilter"] = sort;
        // dto.Order = (ReleasedOnOrder) sort;
             movieList.Movie = await _movieRepository.GetMovieList(dto);
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
