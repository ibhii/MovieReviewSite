using System.Reflection.Metadata.Ecma335;
using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Models.Genre;

namespace MovieReviewSite.Core.Models.Movie.Request;

public class NewMovie
{
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? AgeRate { get; set; }
    public string? Synopsis { get; set; }
    // public string? Poster { get; set; }
    public int Duration { get; set; }
    public int? Type { get; set; }
    public GenreBase? Genre { get; set; }
     
}
