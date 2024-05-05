using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Crew.ViewModels;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class CrewController : Controller
{
    private readonly ILogger<CrewController> _logger;
    private readonly ICrewRepository _crewRepository;
    

    public CrewController(ILogger<CrewController> logger, ICrewRepository crewRepository)
    {
        _logger = logger;
        _crewRepository = crewRepository;
    }

    [HttpGet]
    public async Task<List<BaseCrew>> GetAllCrew()
    {
        return await _crewRepository.GetAllCrew();
    }

    [HttpGet("[action]")]
    public async Task<MoviesForCrew?> GetCrewById([FromQuery] int id)
    {
        return await _crewRepository.GetCrewById(id);
    }

    [HttpGet("[action]")]
    public async Task<List<BaseCrewWithType>> GetCrewByMovieId([FromQuery] int id)
    {
        return await _crewRepository.GetCrewByMovieId(id);
    }

    [HttpPost("[action]")]
    public async Task AddCrew([FromBody] NewCrewRequest dto)
    {
        await _crewRepository.AddCrew(dto);
    }

    [HttpPut("[action]")]
    public async Task UpdateCrew([FromBody] UpdateCrewRequest dto)
    {
        await _crewRepository.UpdateCrew(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteCrew([FromBody] int id)
    {
        await _crewRepository.DeleteCrew(id);
    }

    /// <summary>
    /// adds crew to a movie
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddCrewToMovie(CrewMovieRequest dto)
    {
        await _crewRepository.AddCrewToMovie(dto);
    }

    /// <summary>
    /// removes a crew from movie
    /// </summary>
    /// <param name="dto"></param>
    [HttpDelete]
    public async Task RemoveCrewFromMovie(CrewMovieRequest dto)
    {
        await _crewRepository.RemoveCrewFromMovie(dto);
    }
    
    /// <summary>
    /// return crew details view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetCrewDetailsView(int id)
    {
        var crew = await _crewRepository.GetCrewDetails(id);
        return View(crew);
    }

    /// <summary>
    /// returns view to add or remove crew from movie
    /// </summary>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> ModifyCrewForMovieView(int id)
    {
        var crew = await _crewRepository.GetCrewByMovieId(id);
        var result = new ModifyCrewForMovieViewModel
        {
            CrewType = await _crewRepository.GetCrewTypes(),
            AllCrew = await _crewRepository.GetAllCrew(),
            MovieCrew = await _crewRepository.GetCrewByMovieId(id),
            Movie = await _crewRepository.GetMovieById(id)
        };
        return View(result);
    }


    /// <summary>
    /// returns a view with all crew list
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> GetAllCrewListView()
    {
        var result = await _crewRepository.GetAllCrew();
        return View(result);
    }
    
    /// <summary>
    /// returns view  for adding crew
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> AddCrewView()
    {
        return View(new NewCrewRequest());
    }
    
    /// <summary>
    /// returns view for updating crew
    /// </summary>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> UpdateCrewView(int id)
    {
        var result = new UpdateCrewViewModel()
        {
            Crew = await _crewRepository.GetCrewDetails(id)
        };
        return View(result);
    }


}
