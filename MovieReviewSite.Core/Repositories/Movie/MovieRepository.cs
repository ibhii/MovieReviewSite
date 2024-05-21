using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository : IMovieRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;

    public MovieRepository(ReviewSiteContext context, IReviewRepository reviewRepository,
        IUserRepository userRepository)
    {
        _context = context;
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
    }

    public async Task<MovieBase?> GetMovieById(int id)
    {
        return await _context.Movies.Where(m => m.Id == id).Select(m => new MovieBase()
        {
            Id = m.Id,
            Name = m.Name
        }).SingleOrDefaultAsync();
    }

    public async Task<DataBase.Movie?> GetById(int id)
    {
        return await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddMovie(NewMovie dto)
    {
        //only admins or vip members can add movies so this checks to make sure 
        var isUserAuthorized = await _userRepository.IsUserAdminOrVIP(dto.UserId);
        if (isUserAuthorized)
        {
            var newMovie = new DataBase.Movie()
            {
                Name = !dto.Name.IsNullOrEmpty() ? dto.Name : null,
                Synopsis = !dto.Synopsis.IsNullOrEmpty() ? dto.Synopsis : null,
                Duration = dto.Duration == 0 ? dto.Duration : 0,
                AgeRateId = dto.AgeRate == 0 ? null : dto.AgeRate,
                StatusId = 1,
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow,
                RealeaseDate = dto.ReleaseDate == null ? null : dto.ReleaseDate,
                CreatedBy = dto.UserId,
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateMovie(int id, UpdatedMovie dto)
    {
        //only admins or vip members can update movies so this checks to make sure 
        var isUserAuthorized = await _userRepository.IsUserAdminOrVIP(dto.UserId);
        if (isUserAuthorized)
        {
            var movie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();

            if (movie == null) throw new BadHttpRequestException("this movie does not exist!");
            movie.Name = dto.Name.IsNullOrEmpty() ? movie.Name : dto.Name;
            movie.Duration = dto.Duration == 0 ? movie.Duration : dto.Duration;
            movie.RealeaseDate = dto.ReleaseDate ?? movie.RealeaseDate;
            movie.LastModifiedOn = DateTime.UtcNow;
            movie.AgeRateId = dto.AgeRate == 0 ? movie.AgeRateId : dto.AgeRate;
            movie.Synopsis = dto.Synopsis.IsNullOrEmpty() ? movie.Synopsis : dto.Synopsis;

            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMovie(int id, int userId)
    {
        //only admins can delete movies so this checks to make sure 
        var isUserAuthorized = await _userRepository.IsUserAdmin(userId);
        if (isUserAuthorized)
        {
            var movie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
            var movieCrew = await _context.MovieCrews.Where(m => m.MovieId == id).ToListAsync();
            var movieGenre = await _context.MovieGenres.Where(m => m.MovieId == id).ToListAsync();
            var userMovie =  await _context.UserMovies.Where(m => m.MovieId == id).ToListAsync();
            
            _context.MovieCrews.RemoveRange(movieCrew);
            await _context.SaveChangesAsync();
            _context.MovieGenres.RemoveRange(movieGenre);
            await _context.SaveChangesAsync();
            _context.UserMovies.RemoveRange(userMovie);
            await _context.SaveChangesAsync();

            _context.Movies.Remove(movie!);
            await _context.SaveChangesAsync();
        }
    }
}
