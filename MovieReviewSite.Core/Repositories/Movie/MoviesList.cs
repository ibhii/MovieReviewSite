using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    public async Task<List<MovieList>> GetMovieList()
    {
        var query = await Queryable.Select<DataBase.Movie, MovieList>(_context.Movies, m => new MovieList
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
