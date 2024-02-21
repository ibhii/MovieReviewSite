using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Responses;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    //TODO : join tables movie and genre to get genre and crew
    public async Task<MovieDetail?> GetMovieDetails(int id)
    {
        var query = await  _context.Movies.Where(m => m.Id == id)
            .Select(m => new MovieDetail
            {
                Id = m.Id,
                MovieName = m.Name,
                Image = m.Poster,
                Genre = m.MovieGenres.Where(mg => mg.MovieId == id)
                    .Select(mg => mg.Genre).Select(g => new GenreBase
                    {
                        Id = g.Id,
                        Title = g.Title,
                    }).ToList(),
                Duration = m.Duration,
                // Crew = new 
                   }).SingleOrDefaultAsync();
        return query;
    }
}
