using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> GetAllMoviesList()
    {
        var movieList = new AllMoviesListVewModel();
        var dto = new MovieListRequest
        {
            Search = ""
        };
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
    
    // private string GenerateJwt() {
    //     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    //
    //     //If you've had the login module, you can also use the real user information here
    //     var claims = new[] {
    //         new Claim(JwtRegisteredClaimNames.Sub, "user_name"),
    //         new Claim(JwtRegisteredClaimNames.Email, "user_email"),
    //         new Claim("DateOfJoing", "2022-09-12"),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //     };
    //
    //     var token = new JwtSecurityToken(_config["Jwt:Issuer"],
    //         _config["Jwt:Issuer"],
    //         claims,
    //         expires: DateTime.Now.AddMinutes(120),
    //         signingCredentials: credentials);
    //
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
    //
    //

}
