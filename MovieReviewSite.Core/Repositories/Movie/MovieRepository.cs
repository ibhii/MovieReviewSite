using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.Genre;
using MovieReviewSite.Core.Interfaces.Movie;
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
        var genre = new MovieGenre()
        {
            GenreId = movie.Genre!.Id,
            MovieId = newMovie.Id
        };
        newMovie.MovieGenres.Add(genre);
        await _context.SaveChangesAsync();
    }

    //TODO : fix Genre update
    public async Task UpdateMovie(int id, UpdateMovie movie)
    {
        var updatedMovie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();

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

            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMovie(int id)
    {
        var movie = await _context.Movies.Where(m => m.Id == id).SingleOrDefaultAsync();
        if (movie != null)
        {
         _context.Movies.Remove(movie);
         await _context.SaveChangesAsync();
        }
    }
}
