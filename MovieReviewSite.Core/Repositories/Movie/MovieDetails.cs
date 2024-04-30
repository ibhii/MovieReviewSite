using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
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
        var result = await _context.Movies.Where(m => m.Id == id)
            .Select(m => new MovieDetail
            {
                Id = m.Id,
                MovieName = m.Name,
                Image = m.Poster,
                Duration = m.Duration,
                LastModifiedOn = m.LastModifiedOn,
                CreatedOn = m.CreatedOn,
                ReleaseDate = m.RealeaseDate,
                AgeRating = new BaseIdTitleModel()
                {
                    Id = m.AgeRateId,
                    Title = m.AgeRate!.Title
                },
                Crew = m.MovieCrews.Select(mc => new CrewMovieModel()
                {
                    Id = mc.Crew!.Id,
                    FullName = mc.Crew.FullName,
                    CrewType = new BaseIdTitleModel()
                    {
                        Id = mc.CrewTypeCode,
                        Title = mc.CrewTypeCodeNavigation!.Title
                    }
                }).ToList(),
                Genre = m.MovieGenres.Select(mg => new GenreBase()
                {
                    Id = mg.Genre!.Id,
                    Title = mg.Genre.Title
                }).ToList()!,
                ReviewsCount = m.Reviews.Count
            }).SingleOrDefaultAsync();
        result!.Score = await _reviewRepository.GetScoreAverageByMovieId(result.Id);
        return result;
    }

    public async Task<List<ReviewPreview>> GetMovieReviewsList(int id)
    {
        return await _reviewRepository.GetReviewsByMovieId(id);
    }
}
