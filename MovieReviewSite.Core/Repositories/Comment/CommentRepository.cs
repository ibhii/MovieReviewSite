using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Comment;

public class CommentRepository : ICommentRepository
{
    private readonly ReviewSiteContext _context;

    public CommentRepository(ReviewSiteContext context)
    {
        _context = context;
    }

    public async Task<List<CommentBase>> GetAllCommentsList()
    {
        return await _context.Comments.Select(c => new CommentBase()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
            {
                Id = c.Author!.Id,
                Name = c.Author.FullName,
                RoleCode = c.Author.RoleCode,
                UserName = c.Author.UserName
            },
            // CreatedOn = c.
            //TODO: after CreatedOn was added to the database addd it here
        }).ToListAsync();
    }

    public async Task<List<CommentBase>> GetCommentsByReviewId(int id)
    {
        return await _context.Comments.Where(c => c.ReviewId == id).Select(c => new CommentBase()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
            {
                Id = c.Author!.Id,
                Name = c.Author.FullName,
                RoleCode = c.Author.RoleCode,
                UserName = c.Author.UserName
            },
            // CreatedOn = c.
            //TODO: after CreatedOn was added to the database addd it here
        }).ToListAsync();
    }

    public async Task<CommentBase?> GetCommentById(int id)
    {
        return await _context.Comments.Where(c => c.Id == id).Select(c => new CommentBase()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
            {
                Id = c.Author!.Id,
                Name = c.Author.FullName,
                RoleCode = c.Author.RoleCode,
                UserName = c.Author.UserName
            },
            // CreatedOn = c.
            //TODO: after CreatedOn was added to the database addd it here
        }).SingleOrDefaultAsync();
    }


    public Task AddComment(CommentRequest dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteComment(int id)
    {
        var comment = await _context.Comments.Where(c => c.Id == id).SingleOrDefaultAsync();
        _context.Comments.Remove(comment!);
        await _context.SaveChangesAsync();
    }
}
