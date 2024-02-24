using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;

namespace MovieReviewSite.Controllers;

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
    public async Task<CrewDetailsResponse?> GetCrewById([FromQuery]int id)
    {
        return await _crewRepository.GetCrewById(id);
    }
    public async Task<List<CrewDetailsResponse>> GetCrewByMovieId([FromQuery]int id)
    {
        return await _crewRepository.GetCrewByMovieId(id);
    }

    [HttpPost("[action]")]
    public async Task AddCrew([FromBody]NewCrewRequest dto)
    {
        await _crewRepository.AddCrew(dto);
    }

    [HttpPut("[action]")]
    public async Task UpdateCrew([FromBody]UpdateCrewRequest dto)
    {
        await _crewRepository.UpdateCrew(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteCrew([FromBody]int id)
    {
        await _crewRepository.DeleteCrew(id);
    }
}
