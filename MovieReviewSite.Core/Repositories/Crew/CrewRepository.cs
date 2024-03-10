using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Crew;

public class CrewRepository : ICrewRepository
{
    private readonly ReviewSiteContext _context;

    public CrewRepository(ReviewSiteContext context)
    {
        _context = context;
    }
    public async Task<List<BaseCrew>> GetAllCrew()
    {
        return await _context.Crews.Select(c => new BaseCrew()
        {
            Id = c.Id,
            FullName = c.FullName
        }).ToListAsync();
    }

    public async Task<List<BaseCrew>> GetCrewByMovieId(int id)
    {
        return await _context.MovieCrews.Where(mc => mc.MovieId == id)
            .Select(mc => new BaseCrew()
        {
            Id = mc.CrewId,
            FullName = mc.Crew!.FullName,
        }).ToListAsync();
        
    }
    
    public async Task<CrewWithMoviesResponse?> GetCrewById(int id)
    {
        return await _context.Crews.Where(c => c.Id == id).Select(c => new CrewWithMoviesResponse
        {
            Id = c.Id,
            FullName = c.FullName,
            Movies = c.MovieCrews.Select(mc => new CrewMovieModel()
            {
                MovieId = mc.MovieId,
                CrewType = new BaseIdTitleModel()
                {
                    Id = mc.CrewTypeCode,
                    Title = mc.CrewTypeCodeNavigation!.Title
                },
                MovieName = mc.Movie!.Name
            }).ToList()
        }).SingleOrDefaultAsync();

    }


    public async Task AddCrew(NewCrewRequest dto)
    {
        var crew = new DataBase.Crew()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            IsActive = true,
            IsVisible = true,
            IsAlive = dto.IsAlive,
            BirthDate = dto.BirthDate,
            DeathDate = dto.DeathDate,
            LastModifiedOn = DateTime.UtcNow,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy
        };
        await _context.Crews.AddAsync(crew);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCrew(UpdateCrewRequest dto)
    {
        var crew = await _context.Crews.Where(c => c.Id == dto.Id).SingleOrDefaultAsync();
        crew!.FirstName = dto.FirstName;
        crew.LastName = dto.LastName;
        crew.MiddleName = dto.MiddleName;
        crew.BirthDate = dto.BirthDate;
        crew.DeathDate = dto.DeathDate;
        crew.IsAlive = dto.IsAlive;
        crew.LastModifiedOn = DateTime.UtcNow;
        _context.Crews.Update(crew);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCrew(int id)
    {
        var crew = await _context.Crews.Where(c => c.Id == id).SingleOrDefaultAsync();
        _context.Crews.Remove(crew!);
        await _context.SaveChangesAsync();
    }

    public async Task<CrewDetails?> GetCrewDetails(int id)
    {
        return await _context.Crews.Where(c => c.Id == id)
            .Select(c => new CrewDetails()
            {
                IsAlive = c.IsAlive,
                BirthDate = c.BirthDate,
                // DeathDate = c.DeathDate,
                CreatedOn = c.CreatedOn,
                FullName = c.FullName,
                LastModifiedOn = c.LastModifiedOn,
                MoviesList = c.MovieCrews.Select(mc => new Movies()
                {
                    Id = (int) mc.MovieId!,
                    Name = mc.Movie!.Name,
                    Duration = mc.Movie.Duration,
                    // Rating = mc.Movie.
                    AgeRating = new BaseIdTitleModel()
                    {
                        Id = mc.Movie.AgeRateId,
                        Title = mc.Movie.AgeRate!.Title
                    },
                    ReleaseDate = mc.Movie.RealeaseDate
                    // Image = 
                }).ToList()
            }).SingleOrDefaultAsync();
    
}
}
