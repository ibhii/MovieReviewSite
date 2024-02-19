using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Interfaces.Movie;

public interface  IMovieRepository : IBaseRepository
{
    Task<List<MovieList>> GetMovieList();
    Task<MovieDetail?> GetMovieDetails(int id);
}
