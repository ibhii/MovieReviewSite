using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface ICrewRepository : IBaseRepository
{
    Task<List<BaseCrew>> GetAllCrew();
    Task<CrewWithMoviesResponse?> GetCrewById(int id);
    Task<List<BaseCrew>> GetCrewByMovieId(int id);
    Task AddCrew(NewCrewRequest dto);
    Task UpdateCrew(UpdateCrewRequest dto);
    Task DeleteCrew(int id);
    Task<CrewDetails?> GetCrewDetails(int id);

}
