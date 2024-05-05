using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew.ResponseBase;

namespace MovieReviewSite.Core.Repositories.Crew;

public partial class CrewRepository
{
    public async Task<CrewDetails?> GetCrewDetails(int id)
    {
        var crew = await _context.Crews.Where(c => c.Id == id)
            .Select(c => new CrewDetails()
            {
                Id = c.Id,
                IsAlive = c.IsAlive,
                BirthDate = c.BirthDate,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                // DeathDate = c.DeathDate,
                CreatedOn = c.CreatedOn,
                FullName = c.FullName,
                LastModifiedOn = c.LastModifiedOn,
            }).SingleOrDefaultAsync();
        crew!.MoviesList = await _context.MovieCrews.Where(mc => mc.CrewId == id)
            .Select(mc => new MoviesForCrewDetails()
            {
                Id = (int) mc.MovieId!,
                Name = mc.Movie!.Name,
                Duration = mc.Movie!.Duration,
                AgeRating = new BaseIdTitleModel()
                {
                    Id = mc.Movie.AgeRateId,
                    Title = mc.Movie.AgeRate!.Title
                },
                ReleaseDate = mc.Movie.RealeaseDate,
                CrewType = new BaseIdTitleModel()
                {
                    Id = mc.CrewId,
                    Title = mc.CrewTypeCodeNavigation!.Title
                }
            }).ToListAsync();
        foreach (var movie in crew.MoviesList)
        {
            movie.Score = await _reviewRepository.GetScoreAverageByMovieId(movie.Id);
        }
        return crew;
    }
    
}
