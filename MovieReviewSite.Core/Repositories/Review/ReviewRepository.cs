using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Review;

public class ReviewRepository : IReviewRepository
{
    private readonly ReviewSiteContext _context;
    public ReviewRepository(ReviewSiteContext context)
    {
        _context = context;
    }


    public async Task<List<ReviewBase>> GetAllReviews()
    {
        return await _context.Reviews.Select(r => new ReviewBase()
        {
            Id = r.Id,
            User = new BaseUser()
            {
                Id = r.Author!.Id,
                Name = r.Author.FullName,
                RoleCode = r.Author.RoleCode,
                UserName = r.Author.UserName
            },
            Title = r.Title
        }).ToListAsync();
    }

    public async Task<List<ReviewPreview>> GetReviewsByMovieId(int id)
    {
        return await _context.Reviews.Where(r => r.MovieId == id).Select(r => new ReviewPreview()
        {
            Id = r.Id,
            User = new BaseUser()
            {
                Id = r.Author!.Id,
                Name = r.Author.FullName,
                RoleCode = r.Author.RoleCode,
                UserName = r.Author.UserName
            },
            Title = r.Title,
            Review = r.Review1,
            CommentsCount = r.Comments.Count,
            CreatedOn = r.CreatedOn,
            GivenRate = r.RateCode,
            // LastModified = r
            LikesCount = r.LikesCount
        }).ToListAsync();
    }

    public Task<ReviewDetailes> GetReviewById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task LikeReview(int id)
    {
        var review = await _context.Reviews.Where(r => r.Id == id).SingleOrDefaultAsync();
        review!.LikesCount ++;
    }

    public async Task AddReview(AddReviewRequest dto)
    {
        var chosenMovie = await _context.Reviews.Where(r => r.Id == r.MovieId).SingleOrDefaultAsync();
        

    }

    public async Task UpdateReview(UpdateReviewRequest dto)
    {
        var review = await _context.Reviews.Where(r => r.Id == dto.Id).SingleOrDefaultAsync();
        review!.Title = dto.Title;
        review.Review1 = dto.Review;
        //TODO : after last modified on has been added add it here
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReview(int id)
    {
        var review = await _context.Reviews.Where(r => r.Id == id).SingleOrDefaultAsync();
        _context.Reviews.Remove(review!);
        await _context.SaveChangesAsync();
    }
}
