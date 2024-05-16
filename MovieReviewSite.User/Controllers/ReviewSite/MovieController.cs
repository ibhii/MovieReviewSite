using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.Movie.ViewModels;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieRepository _movieRepository;
    private readonly IUserRepository _userRepository;

    public MovieController(ILogger<MovieController> logger, IMovieRepository movieRepository, IUserRepository userRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }


    /// <summary>
    /// Return a list of movies
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<List<Movies>> GetMoviesList([FromBody] MovieListRequest dto)
    {
        return await _movieRepository.GetMovieList(dto);
    }

    /// <summary>
    /// Returns a movies details 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<MovieDetail?> GetMovieDetail([FromQuery] int id)
    {
        return await _movieRepository.GetMovieDetails(id);
    }

    /// <summary>
    /// Adds a new movie to the database 
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddMovie([FromBody] NewMovie dto)
    {
        await _movieRepository.AddMovie(dto);
    }

    /// <summary>
    /// updates a movie
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    [HttpPost("[action]/{id}")]
    public async Task UpdateMovie(int id, [FromBody] UpdatedMovie dto)
    {
        await _movieRepository.UpdateMovie(id, dto);
    }

    /// <summary>
    /// deletes a movie
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    [HttpPost("[action]/{id}")]
    public async Task DeleteMovie(int id, [FromBody] int userId)
    {
        await _movieRepository.DeleteMovie(id, userId);
    }


    /// <summary>
    /// add a movie to users Watched list
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddMovieToWatched(MovieUser dto)
    {
        await _movieRepository.AddMovieToWatched(dto);
    }

    /// <summary>
    /// adds a movie to users WantToWatch List
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddMovieToWantToWatch(MovieUser dto)
    {
        await _movieRepository.AddMovieToWantToWatch(dto);
    }

    /// <summary>
    /// get a users Watched list
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<List<Movies>> GetWatchedMoviesByUserId(int id)
    {
        return await _movieRepository.GetWatchedMoviesByUserId(id);
    }

    /// <summary>
    /// gets a users WantToWatch list
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<List<Movies>> GetWantToWatchMoviesByUserId(int id)
    {
        return await _movieRepository.GetWantToWatchMoviesByUserId(id);
    }


    /// <summary>
    /// returns movie details view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> MovieDetailsView(int id)
    {
        var movie = await _movieRepository.GetMovieDetails(id);
        var movieDetails = new MovieDetailsViewModel()
        {
            Movie = movie,
        };
        return View(movieDetails);
    }

    /// <summary>
    /// returns view for updating movie
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> UpdateMovieView(int id)
    {
        var movie = await _movieRepository.GetMovieDetails(id);
        var movieDetails = new UpdateMovieViewModel()
        {
            Movie = movie,
        };
        return View(movieDetails);
    }

    /// <summary>
    /// returns view for adding movie
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public IActionResult AddMovieView()
    {
        return View();
    }
    
    [Route("[action]/{id}")]
    public async Task<ActionResult> UserWatchedMoviesView(int id)
    {
        var movie = await _movieRepository.GetWatchedMoviesByUserId(id);
        var user = await _userRepository.GetUserById(id);
        var result = new UseMovieListsViewModel()
        {
            User = user,
            Movies = movie
        };
        
        return View(result);
    }
    
    [Route("[action]/{id}")]
    public async Task<ActionResult> UserWantToWatchMoviesView(int id)
    {
        var movie = await _movieRepository.GetWantToWatchMoviesByUserId(id);
        var user = await _userRepository.GetUserById(id);
        var result = new UseMovieListsViewModel()
        {
            User = user,
            Movies = movie
        };
        
        return View(result);
    }
}
