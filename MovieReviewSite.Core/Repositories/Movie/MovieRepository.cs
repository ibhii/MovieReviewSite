using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.DataBase;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository : IMovieRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IGenreRepository _genreRepository;

    public MovieRepository(ReviewSiteContext context, IGenreRepository genreRepository)
    {
        _context = context;
        _genreRepository = genreRepository;
    }

    public async Task AddMovie(NewMovie movie)
    {
        var newMovie = new DataBase.Movie()
        {
            Name = movie.Name,
            CreatedOn = DateTime.UtcNow,
            Duration = movie.Duration,
            RealeaseDate = movie.ReleaseDate,
            LastModifiedOn = DateTime.UtcNow,
            AgeRateId = movie.AgeRate,
            // Poster = movie,
            TypeId = movie.Type,
            Synopsis = movie.Synopsis,
        };
        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();
    }

    //TODO : fix Genre update
    public async Task UpdateMovie(UpdatedMovie movie)
    {
        var updatedMovie = await _context.Movies.Where(m => m.Id == movie.Id).SingleOrDefaultAsync();

        if (updatedMovie != null)
        {
            updatedMovie.Name = movie.Name;
            updatedMovie.Duration = movie.Duration;
            updatedMovie.RealeaseDate = movie.ReleaseDate;
            updatedMovie.LastModifiedOn = DateTime.UtcNow;
            updatedMovie.AgeRateId = movie.AgeRate;
            // updatedMovie.// Poster = movie;
            updatedMovie.TypeId = movie.Type;
            updatedMovie.Synopsis = movie.Synopsis;
            // updatedMovie.MovieGenres.Where(mg => mg.GenreId == movie.DeletedGenre.Any());

            _context.Update(updatedMovie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMovie(int id)
    {
        var movie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }
}
