using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
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

    public async Task<List<CrewDetailsResponse>> GetCrewByMovieId(int id)
    {
        return await _context.MovieCrews.Where(mc => mc.MovieId == id)
            .Select(mc => new CrewDetailsResponse()
        {
            Id = mc.CrewId,
            CreatedBy = mc.Crew!.CreatedBy,
            FullName = mc.Crew.FullName,
            Movies = mc.Crew.MovieCrews.Select(mc => new CrewMovieModel()
            {
                MovieId = mc.MovieId,
                CrewType = mc.CrewTypeCode,
                MovieName = mc.Movie!.Name
            }).ToList()
        }).ToListAsync();
        
    }
    
    public async Task<CrewDetailsResponse?> GetCrewById(int id)
    {
        return await _context.Crews.Where(c => c.Id == id).Select(c => new CrewDetailsResponse
        {
            Id = c.Id,
            FullName = c.FullName,
            CreatedBy = c.CreatedBy,
            Movies = c.MovieCrews.Select(mc => new CrewMovieModel()
            {
                MovieId = mc.MovieId,
                CrewType = mc.CrewTypeCode,
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
}
