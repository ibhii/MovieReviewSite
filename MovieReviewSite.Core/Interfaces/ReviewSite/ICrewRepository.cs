using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Crew.ViewModels;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface ICrewRepository : IBaseRepository
{
    Task<List<BaseCrew>> GetAllCrew();
    Task<MoviesForCrew?> GetCrewById(int id);
    Task<List<BaseCrewWithType>> GetCrewByMovieId(int id);
    Task AddCrew(NewCrewRequest dto);
    Task UpdateCrew(int id,UpdateCrewRequest dto);
    Task DeleteCrew(int id);
    Task<CrewDetails?> GetCrewDetails(int id);
    Task AddCrewToMovie(CrewMovieRequest dto);
    Task RemoveCrewFromMovie(CrewMovieRequest dto);
    Task<MovieBase?> GetMovieById(int id);
    Task<List<BaseIdTitleModel>> GetCrewTypes();
    Task<BaseIdTitleModel?> GetCrewTypeByCrewIdAndMovieId(int movieId, int crewId);
}
