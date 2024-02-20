using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Controllers;

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
    [HttpGet]
    public async Task<List<MovieList>> GetMoviesList()
    {
        return await _movieRepository.GetMovieList();
    }
    
    /// <summary>
    /// Returns a movies details 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<MovieDetail?> GetMovieDetail(int id)
    {
        return await _movieRepository.GetMovieDetails(id);
    }

    /// <summary>
    /// Adds a new movie to the database 
    /// </summary>
    /// <param name="movie"></param>
    [HttpPost("[action]")]
    public async Task AddMovie(NewMovie dto)
    {
        await _movieRepository.AddMovie(dto);
    }

    /// <summary>
    /// updates a movie
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movie"></param>
    [HttpPut("[action]")]
    public async Task UpdateMovie(int id,UpdateMovie dto)
    {
        await _movieRepository.UpdateMovie(id,dto);
    }

    /// <summary>
    /// deletes a movie
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("[actionn")]
    public async Task DeleteMovie(int id)
    {
        await _movieRepository.DeleteMovie(id);
    }

}
