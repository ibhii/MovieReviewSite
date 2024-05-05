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

    public MovieRepository(ReviewSiteContext context, IReviewRepository reviewRepository)
    {
        _context = context;
        _reviewRepository = reviewRepository;
    }

    public async Task<MovieBase?> GetMovieById(int id)
    {
        return await _context.Movies.Where(m => m.Id == id).Select(m => new MovieBase()
        {
            Id = m.Id,
            Name = m.Name
        }).SingleOrDefaultAsync();
    }
    
    public  async Task<DataBase.Movie?> GetById(int id)
    {
        return await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddMovie(NewMovie movie)
    {
        var newMovie = new DataBase.Movie()
        {
            Name = movie.Name,
            Synopsis = movie.Synopsis,
            Duration = movie.Duration,
            AgeRateId = movie.AgeRate,
            StatusId = 1,
            CreatedOn = DateTime.UtcNow,
            LastModifiedOn = DateTime.UtcNow,
            RealeaseDate = movie.ReleaseDate,
        };
        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMovie(UpdatedMovie dto)
    {
        var movie = await _context.Movies.Where(m => m.Id == dto.Id).SingleOrDefaultAsync();

        if (movie != null)
        {
            movie.Name = dto.Name.IsNullOrEmpty() ? movie.Name : dto.Name ;
            movie.Duration = dto.Duration == 0 ? movie.Duration : dto.Duration;
            movie.RealeaseDate = dto.ReleaseDate;
            movie.LastModifiedOn = DateTime.UtcNow;
            movie.AgeRateId = dto.AgeRate == 0 ? movie.AgeRateId : dto.AgeRate;
            movie.Synopsis = dto.Synopsis.IsNullOrEmpty() ? movie.Synopsis : dto.Synopsis;

            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMovie(int id)
    {
        var movie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
        _context.Movies.Remove(movie!);
        await _context.SaveChangesAsync();
    }
}
