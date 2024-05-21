using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    public async Task AddMovieToWatched(MovieUser dto)
    {
        var userMovie = new UserMovie();
        if (dto.ModifierId != dto.UserId)
        {
            throw new UnauthorizedAccessException("you are not authorized to make changes to this users Movie lists");
        }

        var isMovieListedByUser =
            await _context.UserMovies.AnyAsync(um => um.MovieId == dto.MovieId && um.UserId == dto.UserId);
        if (isMovieListedByUser)
        {
            userMovie = await _context.UserMovies.Where(um => um.MovieId == dto.MovieId && um.UserId == dto.UserId)
                .SingleOrDefaultAsync();

            userMovie!.IsWatched = true;
            userMovie.IsWantToWatch = false;
            _context.UserMovies.Update(userMovie);
            await _context.SaveChangesAsync();
        }
        else
        {
            userMovie.IsWatched = true;
            userMovie.IsWantToWatch = false;
            userMovie.MovieId = dto.MovieId;
            userMovie.UserId = dto.UserId;

            await _context.UserMovies.AddAsync(userMovie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddMovieToWantToWatch(MovieUser dto)
    {
        var userMovie = new UserMovie();
        if (dto.ModifierId != dto.UserId)
        {
            throw new UnauthorizedAccessException("you are not authorized to make changes to this users Movie lists");
        }

        var isMovieListedByUser =
            await _context.UserMovies.AnyAsync(um => um.MovieId == dto.MovieId && um.UserId == dto.UserId);
        if (isMovieListedByUser)
        {
            userMovie = await _context.UserMovies.Where(um => um.MovieId == dto.MovieId && um.UserId == dto.UserId)
                .SingleOrDefaultAsync();

            userMovie!.IsWatched = false;
            userMovie.IsWantToWatch = true;
            _context.UserMovies.Update(userMovie);
            await _context.SaveChangesAsync();
        }
        else
        {
            userMovie.IsWatched = false;
            userMovie.IsWantToWatch = true;
            userMovie.MovieId = dto.MovieId;
            userMovie.UserId = dto.UserId;

            await _context.UserMovies.AddAsync(userMovie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Movies>> GetWatchedMoviesByUserId(int id)
    {
        var result = await _context.UserMovies.Where(um => um.UserId == id && um.IsWatched == true)
            .Select(um => new Movies()
            {
                Id = um.Movie.Id,
                Name = um.Movie.Name,
                Duration = um.Movie.Duration,
                AgeRating = new BaseIdTitleModel()
                {
                    Id = um.Movie.AgeRateId,
                    Title = um.Movie.AgeRate!.Title
                },
                ReviewsCount = um.Movie.Reviews.Count,
                ReleaseDate = um.Movie.RealeaseDate,
            }).ToListAsync();
        foreach (var item in result)
        {
            item.Score = await _reviewRepository.GetScoreAverageByMovieId(item.Id);
        }

        return result;
    }

    public async Task<List<Movies>> GetWantToWatchMoviesByUserId(int id)
    {
        var result = await _context.UserMovies.Where(um => um.UserId == id && um.IsWantToWatch == true)
            .Select(um => new Movies()
            {
                Id = um.Movie.Id,
                Name = um.Movie.Name,
                Duration = um.Movie.Duration,
                AgeRating = new BaseIdTitleModel()
                {
                    Id = um.Movie.AgeRateId,
                    Title = um.Movie.AgeRate!.Title
                },
                ReviewsCount = um.Movie.Reviews.Count,
                ReleaseDate = um.Movie.RealeaseDate,
            }).ToListAsync();
        foreach (var item in result)
        {
            item.Score = await _reviewRepository.GetScoreAverageByMovieId(item.Id);
        }

        return result;
    }
}
