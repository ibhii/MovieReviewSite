using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Review.Responses;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Repositories.Review;

public partial class ReviewRepository
{
    private IReviewRepository _reviewRepositoryImplementation;

    public async Task<List<ReviewPreview>> GetReviewsListByUserId(int id)
    {
        return await _context.Reviews.Where(r => r.AuthorId == id)
            .Select(r => new ReviewPreview()
            {
                Id = r.Id,
                CreatedOn = r.CreatedOn,
                Score = r.ScoreCodeNavigation!.Value,
                LikesCount = r.LikesCount,
                LastModified = r.LastModifiedOn,
                Review = r.Review1,
                CommentsCount = r.Comments.Count,
                Movie = new BaseIdTitleModel()
                {
                    Id = r.MovieId,
                    Title = r.Movie.Name
                },
                User = new BaseUserModel()
                {
                    Id = r.Author!.Id,
                    Name = r.Author.FullName,
                    Role = new BaseRole()
                    {
                        RoleCode = r.Author.RoleCodeNavigation!.Code,
                        Role = r.Author.RoleCodeNavigation.Title
                    },
                    UserName = r.Author.UserName
                },
                Title = r.Title,
            }).ToListAsync();
    }
}
