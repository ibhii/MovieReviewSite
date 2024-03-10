using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Tag.Requests;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Tag;

public partial class TagRepository
{
    public async Task AddTagToMovie(AddTagFromReviewRequest dto)
    {
        var movie = await GetTagsByReviewId(dto.ReviewId);
        var allTags = await GetAllTags();

        if (dto.TagIds!.Any(t => movie.Any(r => t != r.Id)))
        {
            if (allTags.Any(t => t.Title != dto.NewTag))
            {
                var newTag = new DataBase.Tag()
                {
                    Title = dto.NewTag,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = dto.AddedBy
                };
                await _context.AddAsync(newTag);
            }
            foreach (var movieGenres in dto.TagIds!.Select(tagId => new ReviewTag()
                     {
                         ReviewId = dto.ReviewId,
                         TagId = tagId
                     }))
            {
                _context.Add(movieGenres);
            }
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveTagFromMovie(RemoveTagFromReviewRequest dto)
    {
        foreach (var genreId in dto.TagIds!)
        {
            var tagReview = await _context.ReviewTags.Where(rt => rt.ReviewId == dto.ReviewId && rt.TagId == genreId)
                .SingleOrDefaultAsync();
            _context.ReviewTags.Remove(tagReview!);
        }
        await _context.SaveChangesAsync();
    }
}
