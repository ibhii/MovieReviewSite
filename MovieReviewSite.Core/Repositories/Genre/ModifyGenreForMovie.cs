using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Genre.Request;
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
        var movie = await GetGenreByMovieId(dto.MovieId);

        if (dto.GenreIds.Any(g => movie.Any(m => g!.Value != m.Id)))
        {
            foreach (var movieGenres in dto.GenreIds.Select(genreId => new MovieGenre()
                     {
                         MovieId = dto.MovieId,
                         GenreId = genreId
                     }))
            {
                _context.Add(movieGenres);
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveGenreByMovieId(MovieGenreRequest dto)
    {
        foreach (var genreId in dto.GenreIds)
        {
            var movieGenre = await _context.MovieGenres.Where(mg => mg.MovieId == dto.MovieId && mg.GenreId == genreId)
                .SingleOrDefaultAsync();
            _context.MovieGenres.Remove(movieGenre!);
        }

        await _context.SaveChangesAsync();
    }
}
