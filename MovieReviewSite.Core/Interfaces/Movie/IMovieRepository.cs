using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Interfaces.Movie;

public interface  IMovieRepository : IBaseRepository
{
    Task<List<MovieList>> GetMovieList();
    Task<MovieDetail?> GetMovieDetails(int id);
    Task AddMovie(NewMovie movie);
    Task UpdateMovie(int id, UpdateMovie movie);
    Task DeleteMovie(int id);
}
