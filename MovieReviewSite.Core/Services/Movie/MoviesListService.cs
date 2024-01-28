using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Services.Movie;

public partial class MovieBaseService
{
    public async Task<List<MovieList>> GetMovieList()
    {
        var query = await _context.Movies.Select(m => new MovieList
        {
            Id = m.Id,
            MovieName = m.Name,
            ReleaseDate = m.RealeaseDate,
            Duration = m.Duration,
            AgeRating = m.AgeRateId,
            Image = m.Poster
        }).ToListAsync();
        return query;
    }
}
