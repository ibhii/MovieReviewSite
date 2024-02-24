using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Crew;
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
        return await _context.Movies.Where(m => m.Id == id)
            .Select(m => new MovieDetail
            {
                Id = m.Id,
                MovieName = m.Name,
                Image = m.Poster,
                Duration = m.Duration,
                Crew = m.MovieCrews.Select(mc => new BaseCrew()
                {
                    Id = mc.Crew.Id,
                    FullName = mc.Crew.FullName
                }).ToList(),
                Genre = m.MovieGenres.Select(mg => new GenreBase()
                {
                    Id = mg.Genre.Id,
                    Title = mg.Genre.Title
                }).ToList()
            }).SingleOrDefaultAsync();
    }
}
