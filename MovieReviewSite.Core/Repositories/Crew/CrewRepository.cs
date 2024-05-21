using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Repositories.Crew.Extensions;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Crew;

public partial class CrewRepository : ICrewRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;

    public CrewRepository(ReviewSiteContext context, IMovieRepository movieRepository,
        IReviewRepository reviewRepository, IUserRepository userRepository)
    {
        _context = context;
        _movieRepository = movieRepository;
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
    }

    public async Task<List<BaseCrew>> GetAllCrew(AllCrewListRequest dto)
    {
        return await _context.Crews.Search(dto.Search).Select(c => new BaseCrew()
        {
            Id = c.Id,
            FullName = c.FullName
        }).ToListAsync();
    }


    public async Task<MoviesForCrew?> GetCrewById(int id)
    {
        return await _context.Crews.Where(c => c.Id == id).Select(c => new MoviesForCrew
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
        //only admins or vip members can Add crew so this checks to make sure 
        var isUserAuthorized = await _userRepository.IsUserAdminOrVIP(dto.CreatedBy);
        if (isUserAuthorized)
        {
            if (dto.FirstName.IsNullOrEmpty())
            {
                throw new BadHttpRequestException("the crew must at least have a firstname!");
            }

            var crew = new DataBase.Crew()
            {
                FirstName = dto.FirstName,
                LastName = !dto.LastName.IsNullOrEmpty() ? dto.LastName : null,
                MiddleName = !dto.MiddleName.IsNullOrEmpty() ? dto.MiddleName : null,
                IsActive = true,
                IsVisible = true,
                BirthDate = dto.BirthDate == null ? null : dto.BirthDate,
                LastModifiedOn = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy
            };
            await _context.Crews.AddAsync(crew);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateCrew(int id, UpdateCrewRequest dto)
    {
        //only admins or vip members can update Crew so this checks to make sure 
            var crew = await _context.Crews.Where(c => c.Id == id).SingleOrDefaultAsync();
            if (crew == null) throw new ArgumentException("crew does not exist!");
            crew!.FirstName = dto.FirstName.IsNullOrEmpty() ? crew.FirstName : dto.FirstName;
            crew.LastName = dto.LastName.IsNullOrEmpty() ? crew.LastName : dto.LastName;
            crew.MiddleName = dto.MiddleName.IsNullOrEmpty() ? null : dto.MiddleName;
            crew.BirthDate = dto.BirthDate ?? crew.BirthDate;
            crew.LastModifiedOn = DateTime.UtcNow;
            _context.Crews.Update(crew);
            await _context.SaveChangesAsync();
    }

    public async Task DeleteCrew(int id,int userId)
    {
        //only admins can delete Crew so this checks to make sure 
        var isUserAuthorized = await _userRepository.IsUserAdmin(userId);
        if (isUserAuthorized)
        {
            var movieCrew = await _context.MovieCrews.Where(c => c.CrewId == id).ToListAsync();
            var crew = await _context.Crews.Where(c => c.Id == id).SingleOrDefaultAsync();
            
            //removes all crew from movies also
            _context.MovieCrews.RemoveRange(movieCrew);
            await _context.SaveChangesAsync();
            
            _context.Crews.Remove(crew!);
            await _context.SaveChangesAsync();
        }
    }
}
