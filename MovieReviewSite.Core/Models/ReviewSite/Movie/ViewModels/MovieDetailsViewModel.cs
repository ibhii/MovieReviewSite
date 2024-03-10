using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Models.Movie.ViewModels;

public class MovieDetailsViewModel
{
    public MovieDetail? Movie { get; set; }
    public List<ReviewPreview?> Reviews { get; set; }
}
