using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Repositories.Movie.Extensions;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    public async Task<List<Movies>> GetMovieList(MovieListRequest dto)
    {
        var query = await _context.Movies.Search(dto.Search).Select(m => new Movies
        {
            Id = m.Id,
            Name = m.Name,
            ReleaseDate = m.RealeaseDate,
            Duration = m.Duration,
            AgeRating = new BaseIdTitleModel()
            {
                Id = m.AgeRateId,
                Title = m.AgeRate!.Title
            },
            Image = m.Poster,
        }).ToListAsync();
        foreach (var movie in query)
        {
            movie.Score = await _reviewRepository.GetScoreAverageByMovieId(movie.Id);
        }
        return query;
    }
    
}
