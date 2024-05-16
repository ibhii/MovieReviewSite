using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Movie.ViewModels;

public class UseMovieListsViewModel
{
    public List<Movies>? Movies { get; set; }
    public BaseUserModel? User { get; set; }
}
