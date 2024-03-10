using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Movie.Request;

public class  NewMovie : IBaseModel
{
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? AgeRate { get; set; }
    public string? Synopsis { get; set; }
    // public string? Poster { get; set; }
    public int? Duration { get; set; }
    public int? Type { get; set; }
    public int? Status { get; set; }
     
}
