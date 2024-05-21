using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Genre.Request;
using MovieReviewSite.Core.Models.Genre.Response;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Genre;

public partial class GenreRepository
{
    public async Task<List<GenreBase>> GetGenreByMovieId(int id)
    {
        return await _context.MovieGenres.Where(m => m.Movie!.Id == id)
            .Select(mg => new GenreBase()
            {
                Id = mg.GenreId,
                Title = mg.Genre!.Title
            }).ToListAsync();
    }

    public async Task AddGenreByMovieId(MovieGenreRequest dto)
    {
        var movieGenreList = await GetGenreByMovieId(dto.MovieId);
        var movie = await _context.Movies.Where(m => m.Id == dto.MovieId).SingleOrDefaultAsync();
        if (movieGenreList.Any(m => dto.GenreId == m.Id))
            throw new UnauthorizedAccessException("this genre already belongs to this movie!");
        var movieGenres = new MovieGenre()
        {
            MovieId = dto.MovieId,
            GenreId = dto.GenreId
        };
        _context.Add(movieGenres);
        await _context.SaveChangesAsync();

        //changes movie's last modified on field 
        await _movieRepository.UpdateMovieLastModifiedOnById(dto.MovieId);
    }

    public async Task RemoveGenreByMovieId(MovieGenreRequest dto)
    {
        var movieGenre = await _context.MovieGenres.Where(mg => mg.MovieId == dto.MovieId && mg.GenreId == dto.GenreId)
            .SingleOrDefaultAsync();
        _context.MovieGenres.Remove(movieGenre!);

        await _context.SaveChangesAsync();
    }

    public async Task<GenreMovies?> GetMoviesByGenreId(int id)
    {
        var result = await _context.Genres.Where(g => g.Id == id)
            .Select(g => new GenreMovies()
            {
                GenreTitle = g.Title,
                MoviesList = g.MovieGenres.Select(mg => new Movies()
                {
                    Id = (int) mg.MovieId!,
                    Name = mg.Movie!.Name,
                    Duration = mg.Movie.Duration,
                    AgeRating = new BaseIdTitleModel()
                    {
                        Id = mg.Movie.AgeRateId,
                        Title = mg.Movie.AgeRate!.Title
                    },
                    ReleaseDate = mg.Movie.RealeaseDate
                    // Image = 
                }).ToList()
            }).SingleOrDefaultAsync();
        foreach (var movie in result!.MoviesList!)
        {
            movie.Score = await _reviewRepository.GetScoreAverageByMovieId(movie.Id);
        }

        return result;
    }
}
