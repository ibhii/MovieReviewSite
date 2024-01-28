using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;

namespace MovieReviewSite.Core.Interfaces.Movie;

public interface IMovieBaseService
{
    Task<List<MovieList>> GetMovieList();
    Task<MovieDetail?> GetMovieDetails(int id);
}
