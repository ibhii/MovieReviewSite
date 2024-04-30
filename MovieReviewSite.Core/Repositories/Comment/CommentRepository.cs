﻿using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Comment;
using MovieReviewSite.Core.Models.Comment.Requests;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Comment;

public partial class CommentRepository : ICommentRepository
{
    private readonly ReviewSiteContext _context;

    public CommentRepository(ReviewSiteContext context)
    {
        _context = context;
    }

    public async Task<List<BaseComment>> GetAllCommentsList()
    {
        return await _context.Comments.Select(c => new BaseComment()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
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

    public async Task<List<BaseComment>> GetCommentsByReviewId(int id)
    {
        return await _context.Comments.Where(c => c.ReviewId == id).Select(c => new BaseComment()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
            {
                Id = c.Author!.Id,
                Name = c.Author.FullName,
                Role = new BaseRole()
                {
                    RoleCode = c.Author.RoleCodeNavigation!.Code,
                    Role = c.Author.RoleCodeNavigation.Title
                },
                UserName = c.Author.UserName,
            },
            CreatedOn = c.CreatedOn
        }).ToListAsync();
    }

    public async Task<BaseComment?> GetCommentById(int id)
    {
        return await _context.Comments.Where(c => c.Id == id).Select(c => new BaseComment()
        {
            Id = c.Id,
            Comment = c.Comment1,
            User = new BaseUser()
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
            CreatedOn = c.CreatedOn,
        }).SingleOrDefaultAsync();
    }


    public async Task AddComment(int id,CommentRequest dto)
    {
        var comment = new DataBase.Comment()
        {
            CreatedOn = DateTime.UtcNow,
            Comment1 = dto.Comment,
            ReviewId = id,
            AuthorId = dto.UserId,
        };
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteComment(int id)
    {
        var comment = await _context.Comments.Where(c => c.Id == id).SingleOrDefaultAsync();
        _context.Comments.Remove(comment!);
        await _context.SaveChangesAsync();
    }
}
