using MovieReviewSite.Core.Models.Movie.Request;

namespace MovieReviewSite.Core.Models.Movie.ViewModels;

public class UpdateMovieViewModel : MovieDetailsViewModel
{
    public NewMovie DTO { get; set; }
}
