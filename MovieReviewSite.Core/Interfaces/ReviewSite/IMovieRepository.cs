using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface  IMovieRepository : IBaseRepository
{
    Task<List<Movies>> GetMovieList(MovieListRequest dto);
    Task<MovieDetail?> GetMovieDetails(int id);
    Task<MovieBase?> GetMovieById(int id);
    Task AddMovie(NewMovie dto);
    Task UpdateMovie(int id,UpdatedMovie dto);
    Task DeleteMovie(int id,int userId);
    Task<List<ReviewPreview>> GetMovieReviewsList(int id,ReviewListRequest dto);
    Task<List<Movies>> GetMoviesByCrewId(int id);
    Task UpdateMovieLastModifiedOnById(int id);
    Task AddMovieToWatched(MovieUser dto);
    Task AddMovieToWantToWatch(MovieUser dto);
    Task<List<Movies>> GetWatchedMoviesByUserId(int id);
    Task<List<Movies>> GetWantToWatchMoviesByUserId(int id);

}
