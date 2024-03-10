using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Tag;
using MovieReviewSite.Core.Models.Tag.Requests;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
[ApiController]
public class TagController : Controller
{
    private readonly ILogger<TagController> _logger;
    private readonly ITagRepository _tagRepository;
    public TagController(ILogger<TagController> logger,ITagRepository tagRepository)
    {
        _logger = logger;
        _tagRepository = tagRepository;
    }
    
    /// <summary>
    /// gives a list bof all tags
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<BaseTag>> GetAllTags()
    {
        return await _tagRepository.GetAllTags();
    }

    /// <summary>
    /// returns a tag by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<BaseTag?> GetTagById([FromQuery]int id)
    {
        return await _tagRepository.GetTagById(id);
    }

    /// <summary>
    /// returns all tags for a review
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<List<BaseTag>> GetTagsByReviewId([FromQuery]int id)
    {
        return await _tagRepository.GetTagsByReviewId(id);
    }

    /// <summary>
    /// adds a tag
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddTag([FromBody]AddTagRequest dto)
    {
        await _tagRepository.AddTag(dto);
    }

    /// <summary>
    /// removes a tag
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("[action]")]
    public async Task DeleteTag([FromBody]int id)
    {
        await _tagRepository.DeleteTag(id);
    }

    /// <summary>
    /// adds a tag to a review
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("[action]")]
    public async Task AddTagToMovie([FromBody]AddTagFromReviewRequest dto)
    {
        await _tagRepository.AddTagToMovie(dto);
    }

    /// <summary>
    /// removes tags from a review
    /// </summary>
    /// <param name="dto"></param>
    [HttpDelete]
    public async Task RemoveTagFromMovie([FromBody]RemoveTagFromReviewRequest dto)
    {
        await _tagRepository.RemoveTagFromMovie(dto);
    }
    
}
