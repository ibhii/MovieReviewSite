using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Genre.Request;
using MovieReviewSite.Core.Models.Genre.Response;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class GenreController : Controller
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreRepository _genreRepository;

    public GenreController(ILogger<GenreController> logger, IGenreRepository genreRepository)
    {
        _logger = logger;
        _genreRepository = genreRepository;
    }

    [HttpGet]
    public async Task<GenreBase> GetGenre([FromQuery]int id)
    {
        return await _genreRepository.GetGenre(id);
    }

    [HttpGet("[action]")]
    public async Task<List<GenreBase>> GetGenreList()
    {
        return await _genreRepository.GetGenreList();
    }

    [HttpPost]
    public async Task AddGenre([FromBody]GenreBase dto)
    {
        await _genreRepository.AddGenre(dto);
    }

    [HttpPut]
    public async Task UpdateGenre([FromQuery]int id,[FromBody] GenreBase dto)
    {
        await _genreRepository.UpdateGenre(id, dto);
    }

    [HttpDelete]
    public async Task DeleteGenre([FromQuery]int id)
    {
        await _genreRepository.DeleteGenre(id);
    }

    /// <summary>
    /// gets all genres gor a movie
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<List<GenreBase>> GetGenreByMovieId([FromQuery] int id)
    {
        return await _genreRepository.GetGenreByMovieId(id);
    }

    /// <summary>
    /// adds a list of genres to a movie
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddGenreByMovieId([FromBody]MovieGenreRequest dto)
    {
        await _genreRepository.AddGenreByMovieId(dto);
    }

    /// <summary>
    /// removes a list of genres from a movie
    /// </summary>
    /// <param name="dto"></param>
    [HttpDelete("[action]")]
    public async Task RemoveGenreByMovieId([FromBody] MovieGenreRequest dto)
    {
        await _genreRepository.RemoveGenreByMovieId(dto);
    }
    
    /// <summary>
    /// returns all movies related to a genre view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetMoviesByGenreView(int id)
    {
        var genreMovies = await _genreRepository.GetMoviesByGenreId(id);
        return View(genreMovies);
    }
    
    
    
}
