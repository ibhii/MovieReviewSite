using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface  IMovieRepository : IBaseRepository
{
    Task<List<Movies>> GetMovieList(MovieListRequest dto);
    Task<MovieDetail?> GetMovieDetails(int id);
    Task AddMovie(NewMovie movie);
    Task UpdateMovie(UpdatedMovie dto);
    Task DeleteMovie(int id);
    Task<List<ReviewPreview>> GetMovieReviewsList(int id);
}
