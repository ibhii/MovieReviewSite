using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Controllers;

[Route("[controller]")]
[ApiController]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieRepository _movieRepository;

    public MovieController(ILogger<MovieController> logger,IMovieRepository movieRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// Return a list of movies
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<List<MovieList>> GetMoviesList()
    {
        return await _movieRepository.GetMovieList();
    }
    
    /// <summary>
    /// Returns a movies details 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<MovieDetail?> GetMovieDetail([FromQuery]int id)
    {
        return await _movieRepository.GetMovieDetails(id);
    }

    /// <summary>
    /// Adds a new movie to the database 
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddMovie([FromBody]NewMovie dto)
    {
        await _movieRepository.AddMovie(dto);
    }

    /// <summary>
    /// updates a movie
    /// </summary>
    /// <param name="dto"></param>
    [HttpPut("[action]")]
    public async Task UpdateMovie([FromBody]UpdatedMovie dto)
    {
        await _movieRepository.UpdateMovie(dto);
    }

    /// <summary>
    /// deletes a movie
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("[action]")]
    public async Task DeleteMovie([FromQuery]int id)
    {
        await _movieRepository.DeleteMovie(id);
    }

}
