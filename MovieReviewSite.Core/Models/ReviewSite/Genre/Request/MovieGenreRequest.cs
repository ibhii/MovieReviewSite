using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.Genre.Request;

public class MovieGenreRequest
{
    public int MovieId { get; set; }
    public List<int?> GenreIds { get; set; }
}
