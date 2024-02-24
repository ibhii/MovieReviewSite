using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Genre;

public class GenreBase : IBaseModel
{
    public int? Id { get; set; }
    public string? Title { get; set; }
}
