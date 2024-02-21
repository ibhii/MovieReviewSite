using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Genre;

namespace MovieReviewSite.Controllers;

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
}
