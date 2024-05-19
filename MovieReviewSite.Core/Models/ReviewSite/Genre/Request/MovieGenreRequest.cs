using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.Genre.Request;

public class MovieGenreRequest
{
    public int MovieId { get; set; }
    public int? GenreId { get; set; }
    public int?  ModifierRoleCode { get; set; }
}
