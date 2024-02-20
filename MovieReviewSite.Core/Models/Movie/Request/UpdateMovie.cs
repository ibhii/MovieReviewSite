namespace MovieReviewSite.Core.Models.Movie.Request;

public class UpdateMovie : NewMovie
{
    public List<int> AddedGenre { get; set; }
    public List<int> DeletedGenre { get; set; }
}
