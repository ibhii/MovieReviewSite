using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    public async Task<List<Movies>> GetMoviesByCrewId(int id)
    {
        var movies = await _context.MovieCrews.Where(cm => cm.CrewId == id)
            .Select(cm => new Movies()
            {
                Id = (int) cm.MovieId!,
                Name = cm.Movie!.Name,
                Duration = cm.Movie.Duration,
                // Rating = cm.Movie.
                AgeRating = new BaseIdTitleModel()
                {
                    Id = cm.Movie.AgeRateId,
                    Title = cm.Movie.AgeRate!.Title
                },
                ReleaseDate = cm.Movie.RealeaseDate
            }).ToListAsync();
        foreach (var movie in movies)
        {
            var averageScore = await _reviewRepository.GetScoreAverageByMovieId(movie.Id);
            movie.Score = averageScore;
        }

        return movies;
    }
}
