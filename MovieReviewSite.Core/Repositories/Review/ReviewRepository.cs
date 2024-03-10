using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Review;

public partial class ReviewRepository : IReviewRepository
{
    private readonly ReviewSiteContext _context;
    private readonly ICommentRepository _commentRepository;
    private readonly ITagRepository _tagRepository;

    public ReviewRepository(ReviewSiteContext context,ICommentRepository commentRepository, ITagRepository tagRepository)
    {
        _context = context;
        _commentRepository = commentRepository;
        _tagRepository = tagRepository;
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
                Role = new BaseRole()
                {
                    RoleCode = r.Author.RoleCodeNavigation!.Code,
                    Role = r.Author.RoleCodeNavigation.Title
                },
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
                Role = new BaseRole()
                {
                    RoleCode = r.Author.RoleCodeNavigation!.Code,
                    Role = r.Author.RoleCodeNavigation.Title
                },
                UserName = r.Author.UserName
            },
            Movie = new BaseIdTitleModel()
            {
                Id = r.MovieId,
                Title = r.Movie.Name
            },
            Title = r.Title,
            Review = r.Review1,
            CommentsCount = r.Comments.Count,
            CreatedOn = r.CreatedOn,
            Score = r.ScoreCodeNavigation!.Value,
            LastModified = r.LastModifiedOn,
            LikesCount = r.LikesCount
        }).ToListAsync();
    }

    public async Task<ReviewDetails> GetReviewById(int id)
    {
         var review = await _context.Reviews.Where(r => r.Id == id)
            .Select(r => new ReviewDetails()
            {
                Id = r.Id,
                CreatedOn = r.CreatedOn,
                Score = r.ScoreCodeNavigation!.Value,
                LikesCount = r.LikesCount,
                LastModified = r.LastModifiedOn,
                Review = r.Review1,
                CommentsCount = r.Comments.Count,
                User = new BaseUser()
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
            }).SingleOrDefaultAsync();
         review!.Tags = await _tagRepository.GetTagsByReviewId(id);
         review!.Comments = await _commentRepository.GetCommentsByReviewId(id);
        return review!;
    }

    public async Task LikeReview(int id)
    {
        var review = await _context.Reviews.Where(r => r.Id == id).SingleOrDefaultAsync();
        review!.LikesCount += 1;
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
    }

    public async Task AddReview(AddReviewRequest dto,int id)
    {
        var review = new DataBase.Review()
        {
            MovieId = id,
            Title = dto.Title,
            Review1 = dto.Review,
            CreatedOn = DateTime.UtcNow,
            LastModifiedOn = DateTime.UtcNow,
            AuthorId = dto.UserId,
            ScoreCode = dto.GivenRate,
        };
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReview(UpdateReviewRequest dto)
    {
        var review = await _context.Reviews.Where(r => r.Id == dto.Id).SingleOrDefaultAsync();
        review!.Title = dto.Title;
        review.Review1 = dto.Review;
        review.ScoreCode = dto.GivenRate;
        review.LastModifiedOn = DateTime.UtcNow;
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
