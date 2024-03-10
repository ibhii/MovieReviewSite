using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Tag;
using MovieReviewSite.Core.Models.Tag.Requests;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface ITagRepository : IBaseRepository
{
    Task<List<BaseTag>> GetAllTags();
    Task<BaseTag?> GetTagById(int id);
    Task<List<BaseTag>> GetTagsByReviewId(int id);
    Task AddTag(AddTagRequest title);
    Task DeleteTag(int id);
    Task AddTagToMovie(AddTagFromReviewRequest dto);
    Task RemoveTagFromMovie(RemoveTagFromReviewRequest dto);
}
