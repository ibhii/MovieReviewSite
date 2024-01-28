using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Services.Movie;

public partial class MovieBaseService
{
    //TODO : join tables movie and genre to get genre and crew
    public async Task<MovieDetail?> GetMovieDetails(int id)
    {
        var query = await  _context.Movies.Where(m => m.Id == id)
            .Select(m => new MovieDetail
            {
                Id = m.Id,
                MovieName = m.Name,
                Image = m.Poster,
                Genre = m.MovieGenres.Where(mg => mg.MovieId == id)
                    .Select(mg => mg.Genre).Select(g => new GenreBase
                    {
                        Id = g.Id,
                        Title = g.Title,
                    }).ToList(),
                Duration = m.Duration,
                Crew = new List<string>(),
                ReviewList = m.Reviews.Where(r => r.MovieId == id)
                    .Select(r => new ReviewList
                    {
                        Id = r.Id,
                        Review = r.Review1,
                        CommentsCount = r.Comments.Count,
                        Title = r.Title,
                        LikesCount = r.LikesCount,
                        User = new BaseUser
                        {
                            Id = r.Author!.Id,
                            Name = r.Author!.FirstName,
                            UserName = r.Author.UserName,
                            RoleCode = r.Author.RoleCode,
                        },
                    }).ToList()}).SingleOrDefaultAsync();
        return query;
    }
}
