using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Interfaces.Services;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.ViewModels;
using MovieReviewSite.Models;

namespace MovieReviewSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRepository _movieRepository;
    private readonly IConfiguration _config;
    private readonly IOptionsMonitor<CookieAuthenticationOptions> _optionsMonitor;
    public readonly IAuthServices _auth;

    public HomeController(ILogger<HomeController> logger,IMovieRepository movieRepository, IConfiguration config, IAuthServices auth, IOptionsMonitor<CookieAuthenticationOptions> optionsMonitor)
    {
        _logger = logger;
        _movieRepository = movieRepository;
        _config = config;
        _auth = auth;
        _optionsMonitor = optionsMonitor;
    }

    public async Task<IActionResult> GetAllMoviesList(string? searchString,ReleasedOnOrder? sort)
    {
        var movieList = new AllMoviesListVewModel();
        var dto = new MovieListRequest();
        ViewData["CurrentFilter"] = searchString;
        ViewData["DateSortParam"] = sort == ReleasedOnOrder.ReleasedOnAsc ? ReleasedOnOrder.ReleasedOnDesc : ReleasedOnOrder.ReleasedOnAsc;;
        dto.Order = (ReleasedOnOrder?) ViewData["DateSortParam"];
        dto.Search = searchString;
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
