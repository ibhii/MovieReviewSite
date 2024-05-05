using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Genre.Request;
using MovieReviewSite.Core.Models.Genre.Response;
using MovieReviewSite.Core.Models.Genre.ViewModel;
using MovieReviewSite.Core.Models.Movie;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class GenreController : Controller
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreRepository _genreRepository;
    private readonly IMovieRepository _movieRepository;

    public GenreController(ILogger<GenreController> logger, IGenreRepository genreRepository, IMovieRepository movieRepository)
    {
        _logger = logger;
        _genreRepository = genreRepository;
        _movieRepository = movieRepository;
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

    [Route("[action]/{id}")]
    public async Task<ActionResult> ModifyMovieGenreView(int id)
    {
        var movieGenres = await _genreRepository.GetGenreByMovieId(id);
        var movie = await _movieRepository.GetMovieById(id);
        var allGenres = await _genreRepository.GetGenreList();
        var result = new ModifyMovieGenreViewModel()
        {
            Movie = new MovieBase()
            {
                Id = movie!.Id,
                Name = movie.Name
            },
            MovieGenres =  movieGenres.Select(mg => new GenreBase()
            {
                Id = mg.Id,
                Title = mg.Title
            }).ToList(),
            AllGenres = allGenres.Select(g => new GenreBase()
            {
                Id = g.Id,
                Title = g.Title
            }).ToList()
        };
        return View(result);
    }
    
    
    
}
