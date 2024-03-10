using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Tag;
using MovieReviewSite.Core.Models.Tag.Requests;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Tag;

public partial class TagRepository : ITagRepository
{
    private readonly ReviewSiteContext _context;

    public TagRepository(ReviewSiteContext context)
    {
        _context = context;
    }

    public async Task<List<BaseTag>> GetAllTags()
    {
        return await _context.Tags.Select(t => new BaseTag()
        {
            Id = t.Id,
            Title = t.Title
        }).ToListAsync();
    }

    public async Task<BaseTag?> GetTagById(int id)
    {
        return await _context.Tags.Where(t => t.Id == id).Select(t => new BaseTag()
        {
            Id = t.Id,
            Title = t.Title
        }).SingleOrDefaultAsync();
    }

    public async Task<List<BaseTag>> GetTagsByReviewId(int id)
    {
        return await _context.ReviewTags.Where(rt => rt.ReviewId == id)
            .Select(rt => new BaseTag()
            {
                Id = rt.TagId,
                Title = rt.Tag!.Title
            }).ToListAsync();
    }

    public async Task AddTag(AddTagRequest title)
    {
        var tag = new DataBase.Tag()
        {
            Title = title.Title,
            CreatedBy = title.CreatedBy,
            CreatedOn = DateTime.UtcNow
        };

        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTag(int id)
    {
        var tag = await _context.Tags.Where(t => t.Id == id).SingleOrDefaultAsync();
        _context.Tags.Remove(tag!);
        await _context.SaveChangesAsync();
    }

    
}
