using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Repositories.Comment;

public partial class CommentRepository
{
    public async Task<List<BaseComment>> GetCommentsByUserId(int id)
    {
        return await _context.Comments.Where(c => c.AuthorId == id)
            .Select(c => new BaseComment()
            {
                Id = c.Id,
                Comment = c.Comment1,
                User = new BaseUserModel()
                {
                    Id = c.Author!.Id,
                    Name = c.Author.FullName,
                    Role = new BaseRole()
                    {
                        RoleCode = c.Author.RoleCodeNavigation!.Code,
                        Role = c.Author.RoleCodeNavigation.Title
                    },
                    UserName = c.Author.UserName
                },
                CreatedOn = c.CreatedOn
            }).ToListAsync();
    }
}
